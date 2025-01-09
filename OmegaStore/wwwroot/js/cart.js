function loadCart() {
  $.ajax({
    url: "/Cart/GetCart",
    method: "GET",
    success: function (response) {
      $("#cart-body").empty();

      if (response.cartItems.length === 0) {
        $("#cart-body").append(`
                    <tr>
                        <td colspan="6" class="text-center">
                            <img src="../img/cart_banner_image.jpg" />
                            <h4>Chưa có sản phẩm nào trong giỏ hàng... <a href="/Home">Xem sản phẩm</a></h4>
                        </td>
                    </tr>
                `);
      } else {
        const rows = response.cartItems
          .map((item) => {
            const price =
              item.product.price -
              item.product.price * (item.product.discountRate / 100);
            return `
                        <tr>
                            <td>
                                <a href="/Product/${
                                  item.product.slug
                                }" class="d-block" style="width: 60px;">
                                    <img class="img-fluid" src="../img/${
                                      item.product.thumbnail
                                    }" alt="">
                                </a>
                            </td>
                            <td style="font-size: .9rem">
                                <a href="/Product/${
                                  item.product.slug
                                }" class="ellipsis">
                                    ${item.product.name}
                                </a>
                            </td>
                            <td style="font-size: .9rem">${price.toLocaleString()} đ</td>
                            <td>
                                <div class="qty border border-secondary rounded-lg d-flex justify-content-between">
                                    <button class="btn-minus rounded-left"><i class="fa fa-minus"></i></button>
                                    <input type="text" class="quantity" value="${
                                      item.quantity
                                    }">
                                    <button class="btn-plus rounded-right"><i class="fa fa-plus"></i></button>
                                </div>
                            </td>
                            <td style="font-size: .9rem">${(
                              price * item.quantity
                            ).toLocaleString()} đ</td>
                            <td>
                                <a class="btn btn-danger" data-id="${
                                  item.product.id
                                }">
                                    <i class="fa fa-trash"></i>
                                </a>
                            </td>
                        </tr>
                    `;
          })
          .join("");
        $("#cart-body").html(rows);
      }

      $(".cart-content").html(`
                <h1>Giỏ hàng rút gọn</h1>
                <p>Tổng tiền hàng:<span>${response.totalPrice.toLocaleString()} đ</span></p>
                <p>Phí vận chuyển:<span>${response.shippingFee.toLocaleString()} đ</span></p>
                <h2>Thành tiền:<span>${(
                  response.totalPrice + response.shippingFee
                ).toLocaleString()} đ</span></h2>
            `);

      $("#cart-summary-content").html(`
                <p class="m-0" style="font-size: 14px;">Sản phẩm: <span>${
                  response.totalQuantity
                }</span></p>
                <p class="m-0" style="font-size: 14px;">Thanh toán: <span>${response.totalPrice.toLocaleString()} đ</span></p>
            `);
    },
    error: function (xhr, status, error) {
      console.error("Có lỗi xảy ra khi lấy giỏ hàng: ", error);
    },
  });
}

// ready đảm bảo ràng mã jquery chỉ được chạy khi toàn bộ DOM đã được tải xong
$(document).ready(function () {
  loadCart();
  // Dùng jquery không cần phải duyệt qua từng nút
  $("#cart-body").on("click", ".btn-danger", function () {
    const productId = $(this).data("id");

    Swal.fire({
      icon: "question",
      title: "Bạn có chắc chắn muốn xóa sản phẩm này?",
      showCancelButton: true,
      confirmButtonText: "Đồng ý",
      cancelButtonText: "Hủy bỏ",
    }).then((result) => {
      if (result.isConfirmed) {
        $.ajax({
          url: "/Cart/RemoveItem",
          method: "POST",
          data: { productId: productId },
          success: function (response) {
            if (response.success) {
              Swal.fire({
                title: "Thành công",
                text: "Xóa sản phẩm khỏi giỏ hàng thành công",
                icon: "success",
              });
              loadCart();
            } else {
              Swal.fire({
                title: "Lỗi",
                text: response.message,
                icon: "error",
              });
            }
          },
          error: function (xhr, status, error) {
            Swal.fire({
              title: "Lỗi",
              text: "Có lỗi xảy ra khi xóa sản phẩm.",
              icon: "error",
            });
          },
        });
      }
    });
  });

  $("#cart-body").on("click", ".btn-minus", function () {
    const quantityInput = $(this).closest("tr").find(".quantity");
    let quantity = quantityInput.val();
    if (quantity === 1) {
      alert("CC");
      $(this).prop("disabled", true);
    }
  });

  $("#cart-body").on("click", ".btn-plus", function () {
    alert("duy");
  });
});

$(document).ready(function () {
  $(document).on("click", "#btn-add-cart", function () {
    var productId = $(this).data("id");
    var quantity = $("#product-quantity").val() || 1;

    // console.log(productId);
    // alert(quantity);

    $.ajax({
      url: "/cart/addtocart",
      method: "POST",
      data: { productId: productId, quantity: quantity },
      success: function (res) {
        if (res.success) {
          $("#cart-summary-content").html(`
                <p class="m-0" style="font-size: 14px;">Sản phẩm: <span>${
                  res.cartViewModel.totalQuantity
                }</span></p>
                <p class="m-0" style="font-size: 14px;">Thanh toán: <span>${res.cartViewModel.totalPrice.toLocaleString()} đ</span></p>
            `);
          Swal.fire({
            title: "Thông báo",
            text: "Thêm sản phẩm vào giỏ hàng thành công",
            icon: "info",
          });
        } else {
          Swal.fire({
            title: "Thông báo",
            text: "Bạn đã có sản phẩm này trong giỏ hàng, không thể tiếp tục thêm vì số lượng đã vượt quá giới hạn tồn kho",
            icon: "info",
          });
        }
      },
      error: function (err) {
        console.log(err);
      },
    });
  });
});

$(document).ready(function () {
  $(document).on("click", "#btn-clear-cart", function () {
    Swal.fire({
      icon: "question",
      title: "Bạn có chắc chắn muốn xóa toàn bộ giỏ hàng?",
      showCancelButton: true,
      confirmButtonText: "Đồng ý",
      cancelButtonText: "Hủy bỏ",
    }).then((result) => {
      if (result.isConfirmed) {
        $.ajax({
          url: "/cart/clearcart",
          method: "POST",
          success: function (res) {
            if (res.success) {
              Swal.fire({
                title: "Thành công",
                text: "Xóa giỏ hàng thành công",
                icon: "success",
              });
              loadCart();
            } else {
              Swal.fire({
                title: "Lỗi",
                text: "Giỏ hàng đang trống!",
                icon: "error",
              });
            }
          },
          error: function (err) {
            console.log(err);
          },
        });
      }
    });
  });
});
