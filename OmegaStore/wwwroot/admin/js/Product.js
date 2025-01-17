$(document).ready(function () {
    $(document).on("click", ".item.trash", function () {
        const productId = $(this).data("id"); // Lấy ID sản phẩm từ thuộc tính data-id
        const row = $(`#product-${productId}`); // Xác định dòng trong bảng

        // Hiển thị hộp thoại xác nhận xóa
        Swal.fire({
            title: "Bạn có chắc chắn?",
            text: "Sản phẩm sẽ được đánh dấu là đã xóa!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Xác nhận xóa",
            cancelButtonText: "Hủy bỏ"
        }).then((result) => {
            if (result.isConfirmed) {
                // Gửi yêu cầu AJAX xóa sản phẩm
                $.ajax({
                    url: `/Admin/Product/Delete/${productId}`, // API endpoint
                    type: "POST", // Phương thức gọi
                    success: function (response) {
                        if (response.success) {
                            // Hiển thị thông báo thành công
                            Swal.fire({
                                title: "Đã xóa!",
                                text: response.message,
                                icon: "success",
                                confirmButtonText: "OK"
                            }).then((innerResult) => {
                                if (innerResult.isConfirmed) {
                                    // Chỉ reload trang khi người dùng bấm OK trong thông báo thành công
                                    window.location.reload();
                                }
                            });
                        } else {
                            // Hiển thị thông báo lỗi (server trả về)
                            Swal.fire(
                                "Lỗi",
                                response.message,
                                "error"
                            );
                        }
                    },
                    error: function (xhr) {
                        // Hiển thị lỗi không mong đợi
                        Swal.fire(
                            "Lỗi",
                            xhr.responseJSON?.message || "Có lỗi trong quá trình xử lý!",
                            "error"
                        );
                    }
                });
            }
        });
    });
        
   

    let currentSearchQuery = ''; // Lưu lại giá trị tìm kiếm hiện tại

    let Status = 1;  // Trạng thái ban đầu: 1 = Bình thường


        // Hàm tải dữ liệu Product với phân trang và tìm kiếm
        function loadBlogs(page = 1) {
            $.ajax({
                url: '/Admin/Product/List',
                method: 'GET',
                data: { page: page, searchQuery: currentSearchQuery, Status : Status },
                success: function (result) {
                    $('.wg-box').html(result);
                },
                error: function () {
                    alert("Đã xảy ra lỗi khi tải dữ liệu!");
                }
            });
        }
        // Gọi dữ liệu trang đầu tiên khi tới trang Danh sách Products
        $(document).ready(function () {
            loadBlogs();
        });

        // Sự kiện nhấn nút xóa tìm kiếm
        $(document).on("click", "#searchResult", function () {
            $('#search-query').val(''); // Gán giá trị rỗng cho input có id="search-query
            currentSearchQuery = '';
            loadBlogs(); // Tải lại blog từ trang đầu
        });

        // Sự kiện nhấn nút xóa tìm kiếm
        $(document).on("click", "#btn-normal", function () {
            Status = 1;
            loadBlogs(); // Tải lại blog từ trang đầu
            // Thêm lớp 'active' vào nút được nhấn
        });
        $(document).on("click", "#btn-deleted", function () {
            Status = 0;
            loadBlogs(); // Tải lại blog từ trang đầu
            // Thêm lớp 'active' vào nút được nhấn
        });
        // Sự kiện nhấn nút tìm kiếm
        $(document).on("click", "#search-btn", function () {
            currentSearchQuery = $('#search-query').val();
            loadBlogs(); // Tải lại blog từ trang đầu
        });

        // Phân trang
        $(document).on("click", ".link", function () {
            const page = $(this).data("page");
            loadBlogs(page);
        });

        // Sự kiện khi nhấn Enter trong ô tìm kiếm
        $('#search-query').on('keypress', function (e) {
            if (e.which === 13) {
                currentSearchQuery = $(this).val();// Lưu giá trị tìm kiếm

                loadBlogs(); // Tải lại blog từ trang đầu
            }
        });
});

