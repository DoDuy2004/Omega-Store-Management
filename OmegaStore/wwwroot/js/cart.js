function loadCart() {
  $.ajax({
    url: "/Cart/GetCart",
    method: "GET",
    success: function (res) {
      $("#cart-body").empty();

      if (res.cartItems.length === 0) {
        $("#cart-body").append(`
                    <tr>
                        <td colspan="6" class="text-center">
                            <img src="../img/cart_banner_image.jpg" />
                            <h4>Chưa có sản phẩm nào trong giỏ hàng... <a href="/Home">Xem sản phẩm</a></h4>
                        </td>
                    </tr>
                `);
      } else {
        const rows = res.cartItems
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
                            <td style="font-size: .9rem" id="product-price-${item.cartItemId}" data-price="${price}">${price.toLocaleString()} đ</td>
                            <td>
                                <div class="qty border border-secondary rounded-lg d-flex justify-content-between">
                                    <button class="btn-minus rounded-left" data-id="${item.cartItemId}"><i class="fa fa-minus"></i></button>
                                    <input type="text" class="quantity" id="product-quantity-${item.cartItemId}" data-id="${item.cartItemId}" value="${
                                      item.quantity
                                    }">
                                    <button class="btn-plus rounded-right" data-id="${item.cartItemId}"><i class="fa fa-plus"></i></button>
                                </div>
                            </td>
                            <td id="total-${item.cartItemId}" style="font-size: .9rem">${(
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
                <p>Tổng tiền hàng:<span>${res.totalPrice.toLocaleString()} đ</span></p>
                <p>Phí vận chuyển:<span>${res.shippingFee.toLocaleString()} đ</span></p>
                <h2>Thành tiền:<span>${(
                  res.totalPrice + res.shippingFee
                ).toLocaleString()} đ</span></h2>
            `);

      $("#cart-summary-content").html(`
                <p class="m-0" style="font-size: 14px;">Sản phẩm: <span>${
                  res.totalQuantity
                }</span></p>
                <p class="m-0" style="font-size: 14px;">Thanh toán: <span>${res.totalPrice.toLocaleString()} đ</span></p>
            `);
    },
    error: function (err) {
      console.error(err);
    },
  });
}

// ready đảm bảo ràng mã jquery chỉ được chạy khi toàn bộ DOM đã được tải xong
$(function () {
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
                    success: function (res) {
                        if (res.success) {
                            Swal.fire({
                                title: "Thành công",
                                text: "Xóa sản phẩm khỏi giỏ hàng thành công",
                                icon: "success",
                            });
                            loadCart();
                        } else {
                            Swal.fire({
                                title: "Lỗi",
                                text: res.message,
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

$("#cart-body").on("click", ".btn-minus", function () {
    var cartItemId = $(this).data("id");
    var quantity = $(`#product-quantity-${cartItemId}`).val();
    var price = parseFloat($(`#product-price-${cartItemId}`).data("price"));

    $.ajax({
        url: "/cart/decreasequantity",
        method: "POST",
        data: { cartItemId: cartItemId },
        success: function (res) {
            //alert(price);
            if (res.success) {
                $(`#product-quantity-${cartItemId}`).val(--quantity);

                $(`#total-${cartItemId}`).text(`${(price * parseInt(quantity)).toLocaleString() } đ`);

                $(".cart-content").html(`
                    <h1>Giỏ hàng rút gọn</h1>
                    <p>Tổng tiền hàng:<span>${res.cartViewModel.totalPrice.toLocaleString()} đ</span></p>
                    <p>Phí vận chuyển:<span>${res.cartViewModel.shippingFee.toLocaleString()} đ</span></p>
                    <h2>Thành tiền:<span>${(
                    res.cartViewModel.totalPrice + res.cartViewModel.shippingFee
                    ).toLocaleString()} đ</span></h2>
                `);

                $("#cart-summary-content").html(`
                    <p class="m-0" style="font-size: 14px;">Sản phẩm: <span>${res.cartViewModel.totalQuantity
                        }</span></p>
                    <p class="m-0" style="font-size: 14px;">Thanh toán: <span>${res.cartViewModel.totalPrice.toLocaleString()} đ</span></p>
                `);
            }
            else {
                Swal.fire({
                    title: "Thông báo",
                    text: "Số lượng nhỏ nhất là 1",
                    icon: "info",
                });
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
});

$("#cart-body").on("click", ".btn-plus", function () {
    var cartItemId = $(this).data("id");
    var quantity = $(`#product-quantity-${cartItemId}`).val();
    var price = parseFloat($(`#product-price-${cartItemId}`).data("price"));

    $.ajax({
        url: "/cart/increasequantity",
        method: "POST",
        data: { cartItemId: cartItemId },
        success: function (res) {
            if (res.success) {
                $(`#product-quantity-${cartItemId}`).val(++quantity);
                $(`#total-${cartItemId}`).text(`${(price * parseInt(quantity)).toLocaleString()} đ`);
                $(".cart-content").html(`
                    <h1>Giỏ hàng rút gọn</h1>
                    <p>Tổng tiền hàng:<span>${res.cartViewModel.totalPrice.toLocaleString()} đ</span></p>
                    <p>Phí vận chuyển:<span>${res.cartViewModel.shippingFee.toLocaleString()} đ</span></p>
                    <h2>Thành tiền:<span>${(
                    res.cartViewModel.totalPrice + res.cartViewModel.shippingFee
                    ).toLocaleString()} đ</span></h2>
                `);

                $("#cart-summary-content").html(`
                    <p class="m-0" style="font-size: 14px;">Sản phẩm: <span>${res.cartViewModel.totalQuantity
                    }</span></p>
                    <p class="m-0" style="font-size: 14px;">Thanh toán: <span>${res.cartViewModel.totalPrice.toLocaleString()} đ</span></p>
                `);
            }
            else {
                Swal.fire({
                    title: "Thông báo",
                    text: "không thể tiếp tục thêm vì số lượng đã vượt quá giới hạn tồn kho",
                    icon: "info",
                });
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
});

$("#cart-body").on("change", ".quantity", function () {
    var cartItemId = $(this).data("id");
    var quantity = $(this).val();
    var price = parseFloat($(`#product-price-${cartItemId}`).data("price"));

    //alert(cartItemId);
    //alert(quantity);

    $.ajax({
        url: "/cart/updatequantity",
        method: "POST",
        data: { cartItemId: cartItemId, quantity: quantity },
        success: function (res) {
            if (res.success)
            {
                $(this).val(quantity);
                $(`#total-${cartItemId}`).text(`${(price * parseInt(quantity)).toLocaleString()} đ`);
                $(".cart-content").html(`
                    <h1>Giỏ hàng rút gọn</h1>
                    <p>Tổng tiền hàng:<span>${res.cartViewModel.totalPrice.toLocaleString()} đ</span></p>
                    <p>Phí vận chuyển:<span>${res.cartViewModel.shippingFee.toLocaleString()} đ</span></p>
                    <h2>Thành tiền:<span>${(
                    res.cartViewModel.totalPrice + res.cartViewModel.shippingFee
                    ).toLocaleString()} đ</span></h2>
                `);

                $("#cart-summary-content").html(`
                    <p class="m-0" style="font-size: 14px;">Sản phẩm: <span>${res.cartViewModel.totalQuantity}</span></p>
                    <p class="m-0" style="font-size: 14px;">Thanh toán: <span>${res.cartViewModel.totalPrice.toLocaleString()} đ</span></p>
                `);
            }
            else {
                Swal.fire({
                    title: "Thông báo",
                    text: "không thể tiếp tục thêm vì số lượng đã vượt quá giới hạn tồn kho",
                    icon: "info",
                });
            }
        },
        error: function (err) {

            console.log(err);
        }
    });
});

$(function () {
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
      }
    });
  });
});

$(function () {
  $(document).on("click", "#btn-clear-cart", function () {
    Swal.fire({
      icon: "question",
      title: "Bạn có chắc chắn muốn xóa toàn bộ giỏ hàng?",
      showCancelButton: true,
      confirmButtonText: "Đồng ý",
      cancelButtonText: "Hủy bỏ"
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
                icon: "success"
              });
              loadCart();
            } else {
              Swal.fire({
                title: "Lỗi",
                text: "Giỏ hàng đang trống!",
                icon: "error"
              });
            }
          },
          error: function (err) {
            console.log(err);
          }
        });
      }
    });
  });
});
