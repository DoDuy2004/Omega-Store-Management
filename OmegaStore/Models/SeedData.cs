using Microsoft.EntityFrameworkCore;

namespace OmegaStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
				if (!context.Blogs.Any())
				{
					context.Blogs.AddRange(
						new Blog
						{
							
							Author = "Đỗ Duy",
							Title = "Mua kèm deal sốc - giảm đến 70%",
							Thumbnail = "blog1.jpg",
							Slug = "mua-kem-deal-soc-giam-den-70",
                            ListContent = @"<ul class='menu pl-3 mt-3'>
                                                <li><a href='#thoi-gian'>1. Thời gian</a></li>
                                                <li><a href='#noi-dung'>2. Nội dung chương trình</a></li>
                                                <li><a href='#dat-hang-hop-le'>3. Cách thức đặt hàng hợp lệ</a></li>
                                                <li><a href='#doi-tuong-tham-gia'>4. Đối tượng tham gia</a></li>
                                                <li><a href='#luu-y'>5. Lưu ý</a></li>
                                                <li><a href='#cau-hoi'>6. Câu hỏi thường gặp</a></li>
                                            </ul>",
							ShortContent = "Mua kèm deal sốc hơn 130 sản phẩm HOT giảm giá đến 70% khi mua sắm với hóa đơn từ 299K . Áp dụng từ 7.1 ~ 15/1. FREESHIP với đơn từ 290K",
							Content = @"<div class='main-content'>
                                            <h4 class='font-weight-bold' id='thoi-gian'>1. Thời gian</h4>
                                            <p>
                                                Từ <strong>7.1</strong> đến hết ngày <strong>15.1</strong>
                                            </p>
                                            <h4 class='font-weight-bold' id='noi-dung'>
                                                2. Nội dung chương trình
                                            </h4>
                                            <p>
                                                Khi mua sắm với hóa đơn từ <strong>299k</strong>, quý khách sẽ
                                                được tham gia chương trình Mua Kèm Deal Sốc hơn 130 sản phẩm
                                                HOT với giá giảm đến 70%
                                            </p>
                                            <p>
                                                Danh sách sản phẩm thuộc chương trình
                                                <strong>Deal Sốc 2025</strong> quý khách xem tại đây:
                                                <a href='#'>https://omega.vn/collections/deal-soc-2024/</a>
                                            </p>
                                            <p class='font-weight-bold'>Cụ thể như sau:</p>
                                            <p>
                                                - Hóa Đơn (HD) từ <strong>299k</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 99k</span> chỉ với giá
                                                <strong>99k</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>499K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 299K</span> chỉ với giá
                                                <strong>299K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>699K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 499K</span> chỉ với giá
                                                <strong>499K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>899K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 699K</span> chỉ với giá
                                                <strong>699K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>1099K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 899K</span> chỉ với giá
                                                <strong>899K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>1499K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 1099K</span> chỉ với giá
                                                <strong>1099K</strong>
                                            </p>
                                            <p>
                                                <i>Áp dụng mua nhiều sản phẩm Deal Sốc trên cùng 1 hóa đơn</i>
                                            </p>
                                            <p><i>Không giới hạn số lần mua sắm</i></p>
                                            <p><i>Áp dụng FREESHIP đối với hóa đơn từ 290K</i></p>
                                            <p>
                                                <i>
                                                    Không áp dụng sản phẩm Deal Sốc đối với các chương trình
                                                    khuyến mãi khác. Quyền quyết định cuối cùng thuộc về
                                                    Omega
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                3. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                <strong>Ví dụ: </strong>Khách hàng mua 3 sản phẩm trong giỏ
                                                hàng (sản phẩm A = 400.000đ, sản phẩm B = 600.00đ, sản phẩm C
                                                = 500.000đ)
                                            </p>
                                            <p>
                                                Tổng hóa đơn: 1.500.000đ, áp voucher giảm 4% (60K) => Tổng
                                                thanh toán: 1.440.000 đ
                                            </p>
                                            <p>
                                                Quý khách hàng được tham gia chương trình
                                                <strong>Deal Sốc 2024</strong> linh hoạt như sau:
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 1: mua 4 sản phẩm trong danh sách Deal Sốc 99K,
                                                tổng đơn: 1.440.000 đ + (99.000 * 4) = 1.836.000đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 2: mua 2 sản phẩm trong danh sách Deal Sốc 299K và
                                                1 sản phẩm trong danh sách Deal Sốc 99K, tổng đơn: 1.440.000 đ
                                                + (299.000 đ * 2) + 99.000 đ = 2.137.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 3: mua 2 sản phẩm trong danh sách Deal Sốc 499k,
                                                tổng đơn: 1.440.000 đ + (499.000 đ * 2) = 2.438.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 4: mua 1 sản phẩm trong danh sách Deal Sốc 699K và
                                                1 sản phẩm trong danh sách Deal Sốc 299K, tổng đơn: 1.440.000
                                                đ + 699.000 đ + 299.000 đ = 2.438.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 5: mua 1 sản phẩm trong danh sách Deal Sốc 899k và
                                                1 sản phẩm trong danh sách Deal Sốc 99K, tổng đơn: 1.440.000 đ
                                                + 899.000 đ + 99.000 đ = 2.438.000 đ
                                            </p>
                                            <p>
                                                Quý khách có thể tự linh động kết hợp tùy vào giá trị hóa đơn,
                                                có thể mua 1 hoặc nhiều sản phẩm Deal Sốc.
                                            </p>
                                            <p>
                                                Trong trường hợp quý khách hàng gặp khó khăn hoặc chưa nắm rõ
                                                về chương trình. Vui lòng liên hệ Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>Đối với hóa đơn từ 290K, quý khách sẽ được FREESHIP</i>
                                            </p>
                                            <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>
                                                4. Đối tượng tham gia
                                            </h4>
                                            <p>
                                                Tất cả khách hàng mua tại showroom, mua online thông qua
                                                Fanpage Facebook và đặt hàng trên Website
                                                <a href='#'>https://omega.vn</a>
                                            </p>
                                            <h4 class='font-weight-bold' id='luu-y'>5. Lưu ý</h4>
                                            <p>
                                                Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                                trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>
                                                    Không áp dụng đổi trả, bảo hành đối với sản phẩm tham gia
                                                    chương trình <strong>Deal Sốc 2024</strong>
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='cau-hoi'>
                                                6. Câu hỏi thường gặp
                                            </h4>
                                            <p>
                                                <strong>
                                                    Q: Đơn gốc của mình trên 290k có được miễn ship
                                                    không?
                                                </strong><br /><span>A: Có</span>
                                            </p>
                                            <p>
                                                <strong>
                                                    Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                                    gì?
                                                </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                            </p>
                                            <p>
                                                <strong>Q: Chương trình có tích điểm AP cho mình không?</strong><br /><span>A: Có</span>
                                            </p>
                                        </div>",
							CreatedAt = DateTime.Now.AddDays(-12)
						},
						new Blog
						{
							
							Author = "Tấn Phát",
							Title = "[BLACK FRIDAY] GIẢM ĐẾN 70% - NGẬP TRÀN ƯU ĐÃI",
							Thumbnail = "blog2.jpg",
							Slug = "black-friday-giam-den-70-ngap-tran-uu-dai",
							ShortContent = "Giảm giá đến 70% toàn bộ mô hình lắp ráp 3D khi đặt hàng thành công tại website OmegaShop. FREESHIP với đơn từ 290K",
							ListContent = @"<ul class='menu pl-3 mt-3'>              
                                        <li><a href='#noi-dung'>1. Nội dung chương trình</a></li>
                                        <li><a href='#dat-hang-hop-le'>2. Cách thức đặt hàng hợp lệ</a></li>
                                        <li><a href='#doi-tuong-tham-gia'>3. Đối tượng tham gia</a></li>
                                        <li><a href='#luu-y'>4. Lưu ý</a></li>
                                        <li><a href='#cau-hoi'>5. Câu hỏi thường gặp</a></li>
                                    </ul>",
                            Content = @"<div class='main-content'>
                                <h4 class='font-weight-bold' id='noi-dung'>
                                    1. Nội dung chương trình
                                </h4>
                                <p>
                                    Giảm giá đến <strong>70%</strong>, với tất cả sản phẩm  tại OmegaShop. Giá sản phẩm tại website là giá đã giảm.
                                </p>
                                <p>
                                    Xem toàn bộ mô hình tại đây:
                                    <a asp-controller='Product' asp-action='Index'>Sản phẩm</a>
                                </p>
                                <p>
                                    Áp dụng
                                    <strong>FREESHIP</strong> đối với hóa đơn từ<strong>290K</strong>

                                </p>
                                <p>
                                    <i>Không áp dụng đối với các chương trình khuyến mãi khác. Quyền quyết định cuối cùng thuộc về Art Puzzle</i>
                                </p>

                                <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                    2. Cách thức đặt hàng hợp lệ
                                </h4>
                                <p>
                                    Quý khách hàng là thành viên tại OmegaShop, đặt hàng thành công tại website đối với 3 hình thức thanh toán: COD, MOMO và chuyển khoản ngân hàng
                                </p>

                                <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>
                                    3. Đối tượng tham gia
                                </h4>
                                <p>
                                    Tất cả khách hàng mua tại showroom, mua online thông qua
                                    Fanpage Facebook và đặt hàng trên Website
                                    <a href='#'>Omega</a>
                                </p>
                                <h4 class='font-weight-bold' id='luu-y'>4. Lưu ý</h4>
                                <p>
                                    Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                    trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                    <strong>090 8427608</strong> (Mr. Duy)
                                </p>
                                <p>
                                    <i>
                                        Quý khách hàng vui lòng quay phim khi unbox sản phẩm, chúng tôi sẽ không giải quyết bất kỳ khiếu nại nào nếu không có video
                                    </i>
                                </p>
                                <h4 class='font-weight-bold' id='cau-hoi'>
                                    5. Câu hỏi thường gặp
                                </h4>
                                <p>
                                    <strong>
                                        Q: Đơn gốc của mình trên 290k có được miễn ship
                                        không?
                                    </strong><br /><span>A: Có</span>
                                </p>
                                <p>
                                    <strong>
                                        Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                        gì?
                                    </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                </p>
                                <p>
                                    <strong>Q: Chương trình có tích điểm cho mình không?</strong><br /><span>A: Có</span>
                                </p>
                            </div>",

							CreatedAt = DateTime.Now.AddDays(-11)
						},
						new Blog
						{
						
							Author = "Phương Nam",
							Title = "Nhân Đôi Ưu Đãi – Mừng Xuân Giáp Thìn",
							Thumbnail = "blog3.jpg",
							Slug = "nhan-doi-uu-dai-mung-xuan-giap-thin",
							ShortContent = "Gấp đôi ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc hoặc Lân Phát Tài Mini mừng Xuân Giáp Thìn. Khuyến mãi diễn ra từ 20.1 đến 2.2 với hoá đơn từ 599k và miễn phí giao hàng tận nơi",
							ListContent= @"<ul class='menu pl-3 mt-3'>
                                                <li><a href='#thoi-gian'>1. Thời gian</a></li>
                                                <li><a href='#noi-dung'>2. Nội dung chương trình</a></li>
                                                <li><a href='#thong-tin-san-pham'>3. Thông tin sản phẩm Nhân Đôi Ưu Đãi</a></li>
                                                <li><a href='#dat-hang-hop-le'>4. Cách thức đặt hàng hợp lệ</a></li>
                                                <li><a href='#doi-tuong-tham-gia'>5. Đối tượng tham gia</a></li>
                                                <li><a href='#luu-y'>6. Lưu ý</a></li>
                                                <li><a href='#cau-hoi'>7. Câu hỏi thường gặp</a></li>
                                            </ul>",
                            Content = @"<div class='main-content'>
                                            <h4 class='font-weight-bold' id='thoi-gian'>
                                                1. Thời gian
                                            </h4>
                                            <p>
                                                Từ <strong>20.1</strong> đến hết ngày <strong>2.2</strong>
                                            </p>
                                            <h4 class='font-weight-bold' id='noi-dung'>
                                                2. Nội dung chương trình
                                            </h4>
                                            <p>
                                                Khi mua bất kì đơn hàng mô hình tại OmegaShop có giá trị từ 599.000 đ trở lên, bạn sẽ được tặng mô hình Chậu Hoa Nhỏ, Thiên Ngữ Hạc hoặc Lân Phát Tài Mini. Cụ thể như sau:
                                            <p>
                                                – Đơn hàng từ <strong>599.000 đ</strong>, được tặng 1 mô hình nhựa 3D Chậu Hoa Nhỏ (trị giá 78k)
                                            </p>
                                            <p>
                                                – Đơn hàng từ<strong>1.299.000 đ</strong> , được tặng 1 mô hình kim loại 3D Thiên Ngữ Hạc (trị giá 200k)
                                            </p>
                                            <p>
                                                – Đơn hàng từ <strong>2.499.000 đ</strong> , được tặng 1 mô hình kim loại 3D Lân Phát Tài Mini (trị giá 270k)
                                            </p>
                                            <p style='color:red'>
                                                Lưu ý: Chậu Hoa Nhỏ, Thiên Ngữ Hạc và Lân Mini là dạng Blind Box, vì vậy chúng tôi sẽ giao màu ngẫu nhiên.
                                            </p>
                                            <p>
                                                <i>Mỗi khách hàng chỉ được hưởng ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc, Lân Mini tối đa 2 sản phẩm. Ví dụ: 2x Thiên Ngữ Hạc HOẶC 2x Lân Mini HOẶC 1 Thiên Ngữ Hạc và 1 Lân Mini</i>
                                            </p>

                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                3. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                Quý khách hàng là thành viên tại OmegaShop, đặt hàng thành công tại website đối với 3 hình thức thanh toán: COD, MOMO và chuyển khoản ngân hàng
                                            </p>
                                            <h4 class='font-weight-bold' id='thong-tin-san-pham'>
                                                3. Thông tin sản phẩm NHÂN ĐÔI ƯU ĐÃI
                                            </h4>
                                            <p>
                                                Sản phẩm thuộc chương trình bao gồm: Chậu Hoa Nhỏ, Thiên Ngữ Hạc và Lân Phát Tài Mini
                                            </p>
                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                4. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                Giả sử đơn hàng gốc của quý khách sẽ mua là <strong>2.600.000 đ.</strong> Quý khách được hưởng 2 ưu đãi:
                                            </p>
                                            <p>
                                                1. Ưu đãi thuộc chương trình ưu đãi theo giá trị đơn hàng
                                            </p>
                                            <p>
                                                2. Nhân Đôi Ưu Đãi – Mừng Xuân Giáp Thìn (tặng 2 Chậu Hoa Nhỏ hoặc 2 Thiên Ngữ Hạc hoặc 1 Chậu Hoa Nhỏ + 1 Thiên Ngữ Hạc hoặc 1 Lân Mini)
                                            </p>
                                            <p>
                                                Quý khách vui lòng KHÔNG cho sản phẩm thuộc chương trình trên vào giỏ hàng , tại mục <strong>Lưu ý</strong> của bước<strong>Thanh Toán</strong> . Quý khách vui lòng ghi:Thiên Ngữ Hạc, Lân Mini…
                                            </p>
                                            <p>
                                                <strong>Lưu ý:</strong> Giá trị đơn hàng áp dụng Chương Trình Ưu Đãi sẽ bao gồm sản phẩm giảm giá
                                            </p>

                                            <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>5. Đối tượng tham gia</h4>
                                            <p>
                                                Tất cả khách hàng mua tại showroom, mua online thông qua Fanpage Facebook và đặt hàng trên Website OmegaShop
                                            </p>
                                            <p>
                                                <i>
                                                    Mỗi khách hàng chỉ được hưởng ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc, Lân Mini tối đa 2 sản phẩm. Ví dụ: 2x Thiên Ngữ Hạc HOẶC 2x Lân Mini HOẶC 1 Thiên Ngữ Hạc và 1 Lân Mini
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='luu-y'>6. Lưu ý</h4>
                                            <p>
                                                Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                                trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>
                                                    Quý khách hàng vui lòng quay phim khi unbox sản phẩm, chúng tôi sẽ không giải quyết bất kỳ khiếu nại nào nếu không có video
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='cau-hoi'>
                                                7. Câu hỏi thường gặp
                                            </h4>
                                            <p>
                                                <strong>
                                                    Q: Đơn gốc của mình trên 290k có được miễn ship
                                                    không?
                                                </strong><br /><span>A: Có</span>
                                            </p>
                                            <p>
                                                <strong>
                                                    Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                                    gì?
                                                </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                            </p>
                                            <p>
                                                <strong>Q: Chương trình có tích điểm cho mình không?</strong><br /><span>A: Có</span>
                                            </p>
                                        </div>",           
							CreatedAt = DateTime.Now.AddDays(-10)
						},
						new Blog
						{
                     
                            Author = "Thanh Tú",
                            Title = "Mua kèm deal sốc - giảm đến 70%",
                            Thumbnail = "blog4.jpg",
                            Slug = "mua-kem-deal-soc-giam-den-70",
                            ListContent = @"<ul class='menu pl-3 mt-3'>
                                                <li><a href='#thoi-gian'>1. Thời gian</a></li>
                                                <li><a href='#noi-dung'>2. Nội dung chương trình</a></li>
                                                <li><a href='#dat-hang-hop-le'>3. Cách thức đặt hàng hợp lệ</a></li>
                                                <li><a href='#doi-tuong-tham-gia'>4. Đối tượng tham gia</a></li>
                                                <li><a href='#luu-y'>5. Lưu ý</a></li>
                                                <li><a href='#cau-hoi'>6. Câu hỏi thường gặp</a></li>
                                            </ul>",
                            ShortContent = "Mua kèm deal sốc hơn 130 sản phẩm HOT giảm giá đến 70% khi mua sắm với hóa đơn từ 299K . Áp dụng từ 7.1 ~ 15/1. FREESHIP với đơn từ 290K",
                            Content = @"<div class='main-content'>
                                            <h4 class='font-weight-bold' id='thoi-gian'>1. Thời gian</h4>
                                            <p>
                                                Từ <strong>7.1</strong> đến hết ngày <strong>15.1</strong>
                                            </p>
                                            <h4 class='font-weight-bold' id='noi-dung'>
                                                2. Nội dung chương trình
                                            </h4>
                                            <p>
                                                Khi mua sắm với hóa đơn từ <strong>299k</strong>, quý khách sẽ
                                                được tham gia chương trình Mua Kèm Deal Sốc hơn 130 sản phẩm
                                                HOT với giá giảm đến 70%
                                            </p>
                                            <p>
                                                Danh sách sản phẩm thuộc chương trình
                                                <strong>Deal Sốc 2025</strong> quý khách xem tại đây:
                                                <a href='#'>https://omega.vn/collections/deal-soc-2024/</a>
                                            </p>
                                            <p class='font-weight-bold'>Cụ thể như sau:</p>
                                            <p>
                                                - Hóa Đơn (HD) từ <strong>299k</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 99k</span> chỉ với giá
                                                <strong>99k</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>499K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 299K</span> chỉ với giá
                                                <strong>299K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>699K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 499K</span> chỉ với giá
                                                <strong>499K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>899K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 699K</span> chỉ với giá
                                                <strong>699K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>1099K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 899K</span> chỉ với giá
                                                <strong>899K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>1499K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 1099K</span> chỉ với giá
                                                <strong>1099K</strong>
                                            </p>
                                            <p>
                                                <i>Áp dụng mua nhiều sản phẩm Deal Sốc trên cùng 1 hóa đơn</i>
                                            </p>
                                            <p><i>Không giới hạn số lần mua sắm</i></p>
                                            <p><i>Áp dụng FREESHIP đối với hóa đơn từ 290K</i></p>
                                            <p>
                                                <i>
                                                    Không áp dụng sản phẩm Deal Sốc đối với các chương trình
                                                    khuyến mãi khác. Quyền quyết định cuối cùng thuộc về
                                                    Omega
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                3. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                <strong>Ví dụ: </strong>Khách hàng mua 3 sản phẩm trong giỏ
                                                hàng (sản phẩm A = 400.000đ, sản phẩm B = 600.00đ, sản phẩm C
                                                = 500.000đ)
                                            </p>
                                            <p>
                                                Tổng hóa đơn: 1.500.000đ, áp voucher giảm 4% (60K) => Tổng
                                                thanh toán: 1.440.000 đ
                                            </p>
                                            <p>
                                                Quý khách hàng được tham gia chương trình
                                                <strong>Deal Sốc 2024</strong> linh hoạt như sau:
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 1: mua 4 sản phẩm trong danh sách Deal Sốc 99K,
                                                tổng đơn: 1.440.000 đ + (99.000 * 4) = 1.836.000đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 2: mua 2 sản phẩm trong danh sách Deal Sốc 299K và
                                                1 sản phẩm trong danh sách Deal Sốc 99K, tổng đơn: 1.440.000 đ
                                                + (299.000 đ * 2) + 99.000 đ = 2.137.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 3: mua 2 sản phẩm trong danh sách Deal Sốc 499k,
                                                tổng đơn: 1.440.000 đ + (499.000 đ * 2) = 2.438.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 4: mua 1 sản phẩm trong danh sách Deal Sốc 699K và
                                                1 sản phẩm trong danh sách Deal Sốc 299K, tổng đơn: 1.440.000
                                                đ + 699.000 đ + 299.000 đ = 2.438.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 5: mua 1 sản phẩm trong danh sách Deal Sốc 899k và
                                                1 sản phẩm trong danh sách Deal Sốc 99K, tổng đơn: 1.440.000 đ
                                                + 899.000 đ + 99.000 đ = 2.438.000 đ
                                            </p>
                                            <p>
                                                Quý khách có thể tự linh động kết hợp tùy vào giá trị hóa đơn,
                                                có thể mua 1 hoặc nhiều sản phẩm Deal Sốc.
                                            </p>
                                            <p>
                                                Trong trường hợp quý khách hàng gặp khó khăn hoặc chưa nắm rõ
                                                về chương trình. Vui lòng liên hệ Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>Đối với hóa đơn từ 290K, quý khách sẽ được FREESHIP</i>
                                            </p>
                                            <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>
                                                4. Đối tượng tham gia
                                            </h4>
                                            <p>
                                                Tất cả khách hàng mua tại showroom, mua online thông qua
                                                Fanpage Facebook và đặt hàng trên Website
                                                <a href='#'>https://omega.vn</a>
                                            </p>
                                            <h4 class='font-weight-bold' id='luu-y'>5. Lưu ý</h4>
                                            <p>
                                                Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                                trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>
                                                    Không áp dụng đổi trả, bảo hành đối với sản phẩm tham gia
                                                    chương trình <strong>Deal Sốc 2024</strong>
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='cau-hoi'>
                                                6. Câu hỏi thường gặp
                                            </h4>
                                            <p>
                                                <strong>
                                                    Q: Đơn gốc của mình trên 290k có được miễn ship
                                                    không?
                                                </strong><br /><span>A: Có</span>
                                            </p>
                                            <p>
                                                <strong>
                                                    Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                                    gì?
                                                </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                            </p>
                                            <p>
                                                <strong>Q: Chương trình có tích điểm AP cho mình không?</strong><br /><span>A: Có</span>
                                            </p>
                                        </div>",
                            CreatedAt = DateTime.Now.AddDays(-9)
                        },
						new Blog
						{
                      
                            Author = "Anh Tú",
                            Title = "[BLACK FRIDAY] GIẢM ĐẾN 70% - NGẬP TRÀN ƯU ĐÃI",
                            Thumbnail = "blog5.jpg",
                            Slug = "black-friday-giam-den-70-ngap-tran-uu-dai",
                            ShortContent = "Giảm giá đến 70% toàn bộ mô hình lắp ráp 3D khi đặt hàng thành công tại website OmegaShop. FREESHIP với đơn từ 290K",
                            ListContent = @"<ul class='menu pl-3 mt-3'>              
                                        <li><a href='#noi-dung'>1. Nội dung chương trình</a></li>
                                        <li><a href='#dat-hang-hop-le'>2. Cách thức đặt hàng hợp lệ</a></li>
                                        <li><a href='#doi-tuong-tham-gia'>3. Đối tượng tham gia</a></li>
                                        <li><a href='#luu-y'>4. Lưu ý</a></li>
                                        <li><a href='#cau-hoi'>5. Câu hỏi thường gặp</a></li>
                                    </ul>",
                            Content = @"<div class='main-content'>
                                <h4 class='font-weight-bold' id='noi-dung'>
                                    1. Nội dung chương trình
                                </h4>
                                <p>
                                    Giảm giá đến <strong>70%</strong>, với tất cả sản phẩm  tại OmegaShop. Giá sản phẩm tại website là giá đã giảm.
                                </p>
                                <p>
                                    Xem toàn bộ mô hình tại đây:
                                    <a asp-controller='Product' asp-action='Index'>Sản phẩm</a>
                                </p>
                                <p>
                                    Áp dụng
                                    <strong>FREESHIP</strong> đối với hóa đơn từ<strong>290K</strong>

                                </p>
                                <p>
                                    <i>Không áp dụng đối với các chương trình khuyến mãi khác. Quyền quyết định cuối cùng thuộc về Art Puzzle</i>
                                </p>

                                <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                    2. Cách thức đặt hàng hợp lệ
                                </h4>
                                <p>
                                    Quý khách hàng là thành viên tại OmegaShop, đặt hàng thành công tại website đối với 3 hình thức thanh toán: COD, MOMO và chuyển khoản ngân hàng
                                </p>

                                <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>
                                    3. Đối tượng tham gia
                                </h4>
                                <p>
                                    Tất cả khách hàng mua tại showroom, mua online thông qua
                                    Fanpage Facebook và đặt hàng trên Website
                                    <a href='#'>Omega</a>
                                </p>
                                <h4 class='font-weight-bold' id='luu-y'>4. Lưu ý</h4>
                                <p>
                                    Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                    trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                    <strong>090 8427608</strong> (Mr. Duy)
                                </p>
                                <p>
                                    <i>
                                        Quý khách hàng vui lòng quay phim khi unbox sản phẩm, chúng tôi sẽ không giải quyết bất kỳ khiếu nại nào nếu không có video
                                    </i>
                                </p>
                                <h4 class='font-weight-bold' id='cau-hoi'>
                                    5. Câu hỏi thường gặp
                                </h4>
                                <p>
                                    <strong>
                                        Q: Đơn gốc của mình trên 290k có được miễn ship
                                        không?
                                    </strong><br /><span>A: Có</span>
                                </p>
                                <p>
                                    <strong>
                                        Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                        gì?
                                    </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                </p>
                                <p>
                                    <strong>Q: Chương trình có tích điểm cho mình không?</strong><br /><span>A: Có</span>
                                </p>
                            </div>",

                            CreatedAt = DateTime.Now.AddDays(-8)
                        },
						new Blog
						{
                       
                            Author = "Hoàng Ánh",
                            Title = "Nhân Đôi Ưu Đãi – Mừng Xuân Giáp Thìn",
                            Thumbnail = "blog6.jpg",
                            Slug = "nhan-doi-uu-dai-mung-xuan-giap-thin",
                            ShortContent = "Gấp đôi ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc hoặc Lân Phát Tài Mini mừng Xuân Giáp Thìn. Khuyến mãi diễn ra từ 20.1 đến 2.2 với hoá đơn từ 599k và miễn phí giao hàng tận nơi",
                            ListContent = @"<ul class='menu pl-3 mt-3'>
                                                <li><a href='#thoi-gian'>1. Thời gian</a></li>
                                                <li><a href='#noi-dung'>2. Nội dung chương trình</a></li>
                                                <li><a href='#thong-tin-san-pham'>3. Thông tin sản phẩm Nhân Đôi Ưu Đãi</a></li>
                                                <li><a href='#dat-hang-hop-le'>4. Cách thức đặt hàng hợp lệ</a></li>
                                                <li><a href='#doi-tuong-tham-gia'>5. Đối tượng tham gia</a></li>
                                                <li><a href='#luu-y'>6. Lưu ý</a></li>
                                                <li><a href='#cau-hoi'>7. Câu hỏi thường gặp</a></li>
                                            </ul>",
                            Content = @"<div class='main-content'>
                                            <h4 class='font-weight-bold' id='thoi-gian'>
                                                1. Thời gian
                                            </h4>
                                            <p>
                                                Từ <strong>20.1</strong> đến hết ngày <strong>2.2</strong>
                                            </p>
                                            <h4 class='font-weight-bold' id='noi-dung'>
                                                2. Nội dung chương trình
                                            </h4>
                                            <p>
                                                Khi mua bất kì đơn hàng mô hình tại OmegaShop có giá trị từ 599.000 đ trở lên, bạn sẽ được tặng mô hình Chậu Hoa Nhỏ, Thiên Ngữ Hạc hoặc Lân Phát Tài Mini. Cụ thể như sau:
                                            <p>
                                                – Đơn hàng từ <strong>599.000 đ</strong>, được tặng 1 mô hình nhựa 3D Chậu Hoa Nhỏ (trị giá 78k)
                                            </p>
                                            <p>
                                                – Đơn hàng từ<strong>1.299.000 đ</strong> , được tặng 1 mô hình kim loại 3D Thiên Ngữ Hạc (trị giá 200k)
                                            </p>
                                            <p>
                                                – Đơn hàng từ <strong>2.499.000 đ</strong> , được tặng 1 mô hình kim loại 3D Lân Phát Tài Mini (trị giá 270k)
                                            </p>
                                            <p style='color:red'>
                                                Lưu ý: Chậu Hoa Nhỏ, Thiên Ngữ Hạc và Lân Mini là dạng Blind Box, vì vậy chúng tôi sẽ giao màu ngẫu nhiên.
                                            </p>
                                            <p>
                                                <i>Mỗi khách hàng chỉ được hưởng ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc, Lân Mini tối đa 2 sản phẩm. Ví dụ: 2x Thiên Ngữ Hạc HOẶC 2x Lân Mini HOẶC 1 Thiên Ngữ Hạc và 1 Lân Mini</i>
                                            </p>

                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                3. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                Quý khách hàng là thành viên tại OmegaShop, đặt hàng thành công tại website đối với 3 hình thức thanh toán: COD, MOMO và chuyển khoản ngân hàng
                                            </p>
                                            <h4 class='font-weight-bold' id='thong-tin-san-pham'>
                                                3. Thông tin sản phẩm NHÂN ĐÔI ƯU ĐÃI
                                            </h4>
                                            <p>
                                                Sản phẩm thuộc chương trình bao gồm: Chậu Hoa Nhỏ, Thiên Ngữ Hạc và Lân Phát Tài Mini
                                            </p>
                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                4. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                Giả sử đơn hàng gốc của quý khách sẽ mua là <strong>2.600.000 đ.</strong> Quý khách được hưởng 2 ưu đãi:
                                            </p>
                                            <p>
                                                1. Ưu đãi thuộc chương trình ưu đãi theo giá trị đơn hàng
                                            </p>
                                            <p>
                                                2. Nhân Đôi Ưu Đãi – Mừng Xuân Giáp Thìn (tặng 2 Chậu Hoa Nhỏ hoặc 2 Thiên Ngữ Hạc hoặc 1 Chậu Hoa Nhỏ + 1 Thiên Ngữ Hạc hoặc 1 Lân Mini)
                                            </p>
                                            <p>
                                                Quý khách vui lòng KHÔNG cho sản phẩm thuộc chương trình trên vào giỏ hàng , tại mục <strong>Lưu ý</strong> của bước<strong>Thanh Toán</strong> . Quý khách vui lòng ghi:Thiên Ngữ Hạc, Lân Mini…
                                            </p>
                                            <p>
                                                <strong>Lưu ý:</strong> Giá trị đơn hàng áp dụng Chương Trình Ưu Đãi sẽ bao gồm sản phẩm giảm giá
                                            </p>

                                            <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>5. Đối tượng tham gia</h4>
                                            <p>
                                                Tất cả khách hàng mua tại showroom, mua online thông qua Fanpage Facebook và đặt hàng trên Website OmegaShop
                                            </p>
                                            <p>
                                                <i>
                                                    Mỗi khách hàng chỉ được hưởng ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc, Lân Mini tối đa 2 sản phẩm. Ví dụ: 2x Thiên Ngữ Hạc HOẶC 2x Lân Mini HOẶC 1 Thiên Ngữ Hạc và 1 Lân Mini
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='luu-y'>6. Lưu ý</h4>
                                            <p>
                                                Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                                trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>
                                                    Quý khách hàng vui lòng quay phim khi unbox sản phẩm, chúng tôi sẽ không giải quyết bất kỳ khiếu nại nào nếu không có video
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='cau-hoi'>
                                                7. Câu hỏi thường gặp
                                            </h4>
                                            <p>
                                                <strong>
                                                    Q: Đơn gốc của mình trên 290k có được miễn ship
                                                    không?
                                                </strong><br /><span>A: Có</span>
                                            </p>
                                            <p>
                                                <strong>
                                                    Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                                    gì?
                                                </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                            </p>
                                            <p>
                                                <strong>Q: Chương trình có tích điểm cho mình không?</strong><br /><span>A: Có</span>
                                            </p>
                                        </div>",
                            CreatedAt = DateTime.Now.AddDays(-7)
                        },
						new Blog
						{
					
							Author = "Ri Đỗ",
                            Title = "Mua kèm deal sốc - giảm đến 70%",
                            Thumbnail = "blog7.jpg",
                            Slug = "mua-kem-deal-soc-giam-den-70",
                            ListContent = @"<ul class='menu pl-3 mt-3'>
                                                <li><a href='#thoi-gian'>1. Thời gian</a></li>
                                                <li><a href='#noi-dung'>2. Nội dung chương trình</a></li>
                                                <li><a href='#dat-hang-hop-le'>3. Cách thức đặt hàng hợp lệ</a></li>
                                                <li><a href='#doi-tuong-tham-gia'>4. Đối tượng tham gia</a></li>
                                                <li><a href='#luu-y'>5. Lưu ý</a></li>
                                                <li><a href='#cau-hoi'>6. Câu hỏi thường gặp</a></li>
                                            </ul>",
                            ShortContent = "Mua kèm deal sốc hơn 130 sản phẩm HOT giảm giá đến 70% khi mua sắm với hóa đơn từ 299K . Áp dụng từ 7.1 ~ 15/1. FREESHIP với đơn từ 290K",
                            Content = @"<div class='main-content'>
                                            <h4 class='font-weight-bold' id='thoi-gian'>1. Thời gian</h4>
                                            <p>
                                                Từ <strong>7.1</strong> đến hết ngày <strong>15.1</strong>
                                            </p>
                                            <h4 class='font-weight-bold' id='noi-dung'>
                                                2. Nội dung chương trình
                                            </h4>
                                            <p>
                                                Khi mua sắm với hóa đơn từ <strong>299k</strong>, quý khách sẽ
                                                được tham gia chương trình Mua Kèm Deal Sốc hơn 130 sản phẩm
                                                HOT với giá giảm đến 70%
                                            </p>
                                            <p>
                                                Danh sách sản phẩm thuộc chương trình
                                                <strong>Deal Sốc 2025</strong> quý khách xem tại đây:
                                                <a href='#'>https://omega.vn/collections/deal-soc-2024/</a>
                                            </p>
                                            <p class='font-weight-bold'>Cụ thể như sau:</p>
                                            <p>
                                                - Hóa Đơn (HD) từ <strong>299k</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 99k</span> chỉ với giá
                                                <strong>99k</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>499K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 299K</span> chỉ với giá
                                                <strong>299K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>699K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 499K</span> chỉ với giá
                                                <strong>499K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>899K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 699K</span> chỉ với giá
                                                <strong>699K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>1099K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 899K</span> chỉ với giá
                                                <strong>899K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>1499K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 1099K</span> chỉ với giá
                                                <strong>1099K</strong>
                                            </p>
                                            <p>
                                                <i>Áp dụng mua nhiều sản phẩm Deal Sốc trên cùng 1 hóa đơn</i>
                                            </p>
                                            <p><i>Không giới hạn số lần mua sắm</i></p>
                                            <p><i>Áp dụng FREESHIP đối với hóa đơn từ 290K</i></p>
                                            <p>
                                                <i>
                                                    Không áp dụng sản phẩm Deal Sốc đối với các chương trình
                                                    khuyến mãi khác. Quyền quyết định cuối cùng thuộc về
                                                    Omega
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                3. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                <strong>Ví dụ: </strong>Khách hàng mua 3 sản phẩm trong giỏ
                                                hàng (sản phẩm A = 400.000đ, sản phẩm B = 600.00đ, sản phẩm C
                                                = 500.000đ)
                                            </p>
                                            <p>
                                                Tổng hóa đơn: 1.500.000đ, áp voucher giảm 4% (60K) => Tổng
                                                thanh toán: 1.440.000 đ
                                            </p>
                                            <p>
                                                Quý khách hàng được tham gia chương trình
                                                <strong>Deal Sốc 2024</strong> linh hoạt như sau:
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 1: mua 4 sản phẩm trong danh sách Deal Sốc 99K,
                                                tổng đơn: 1.440.000 đ + (99.000 * 4) = 1.836.000đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 2: mua 2 sản phẩm trong danh sách Deal Sốc 299K và
                                                1 sản phẩm trong danh sách Deal Sốc 99K, tổng đơn: 1.440.000 đ
                                                + (299.000 đ * 2) + 99.000 đ = 2.137.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 3: mua 2 sản phẩm trong danh sách Deal Sốc 499k,
                                                tổng đơn: 1.440.000 đ + (499.000 đ * 2) = 2.438.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 4: mua 1 sản phẩm trong danh sách Deal Sốc 699K và
                                                1 sản phẩm trong danh sách Deal Sốc 299K, tổng đơn: 1.440.000
                                                đ + 699.000 đ + 299.000 đ = 2.438.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 5: mua 1 sản phẩm trong danh sách Deal Sốc 899k và
                                                1 sản phẩm trong danh sách Deal Sốc 99K, tổng đơn: 1.440.000 đ
                                                + 899.000 đ + 99.000 đ = 2.438.000 đ
                                            </p>
                                            <p>
                                                Quý khách có thể tự linh động kết hợp tùy vào giá trị hóa đơn,
                                                có thể mua 1 hoặc nhiều sản phẩm Deal Sốc.
                                            </p>
                                            <p>
                                                Trong trường hợp quý khách hàng gặp khó khăn hoặc chưa nắm rõ
                                                về chương trình. Vui lòng liên hệ Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>Đối với hóa đơn từ 290K, quý khách sẽ được FREESHIP</i>
                                            </p>
                                            <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>
                                                4. Đối tượng tham gia
                                            </h4>
                                            <p>
                                                Tất cả khách hàng mua tại showroom, mua online thông qua
                                                Fanpage Facebook và đặt hàng trên Website
                                                <a href='#'>https://omega.vn</a>
                                            </p>
                                            <h4 class='font-weight-bold' id='luu-y'>5. Lưu ý</h4>
                                            <p>
                                                Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                                trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>
                                                    Không áp dụng đổi trả, bảo hành đối với sản phẩm tham gia
                                                    chương trình <strong>Deal Sốc 2024</strong>
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='cau-hoi'>
                                                6. Câu hỏi thường gặp
                                            </h4>
                                            <p>
                                                <strong>
                                                    Q: Đơn gốc của mình trên 290k có được miễn ship
                                                    không?
                                                </strong><br /><span>A: Có</span>
                                            </p>
                                            <p>
                                                <strong>
                                                    Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                                    gì?
                                                </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                            </p>
                                            <p>
                                                <strong>Q: Chương trình có tích điểm AP cho mình không?</strong><br /><span>A: Có</span>
                                            </p>
                                        </div>",
                            CreatedAt = DateTime.Now.AddDays(-6)
                        },
						new Blog
						{
					
                            Author = "Tú Moow",
                            Title = "[BLACK FRIDAY] GIẢM ĐẾN 70% - NGẬP TRÀN ƯU ĐÃI",
                            Thumbnail = "blog8.jpg",
                            Slug = "black-friday-giam-den-70-ngap-tran-uu-dai",
                            ShortContent = "Giảm giá đến 70% toàn bộ mô hình lắp ráp 3D khi đặt hàng thành công tại website OmegaShop. FREESHIP với đơn từ 290K",
                            ListContent = @"<ul class='menu pl-3 mt-3'>              
                                        <li><a href='#noi-dung'>1. Nội dung chương trình</a></li>
                                        <li><a href='#dat-hang-hop-le'>2. Cách thức đặt hàng hợp lệ</a></li>
                                        <li><a href='#doi-tuong-tham-gia'>3. Đối tượng tham gia</a></li>
                                        <li><a href='#luu-y'>4. Lưu ý</a></li>
                                        <li><a href='#cau-hoi'>5. Câu hỏi thường gặp</a></li>
                                    </ul>",
                            Content = @"<div class='main-content'>
                                <h4 class='font-weight-bold' id='noi-dung'>
                                    1. Nội dung chương trình
                                </h4>
                                <p>
                                    Giảm giá đến <strong>70%</strong>, với tất cả sản phẩm  tại OmegaShop. Giá sản phẩm tại website là giá đã giảm.
                                </p>
                                <p>
                                    Xem toàn bộ mô hình tại đây:
                                    <a asp-controller='Product' asp-action='Index'>Sản phẩm</a>
                                </p>
                                <p>
                                    Áp dụng
                                    <strong>FREESHIP</strong> đối với hóa đơn từ<strong>290K</strong>

                                </p>
                                <p>
                                    <i>Không áp dụng đối với các chương trình khuyến mãi khác. Quyền quyết định cuối cùng thuộc về Art Puzzle</i>
                                </p>

                                <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                    2. Cách thức đặt hàng hợp lệ
                                </h4>
                                <p>
                                    Quý khách hàng là thành viên tại OmegaShop, đặt hàng thành công tại website đối với 3 hình thức thanh toán: COD, MOMO và chuyển khoản ngân hàng
                                </p>

                                <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>
                                    3. Đối tượng tham gia
                                </h4>
                                <p>
                                    Tất cả khách hàng mua tại showroom, mua online thông qua
                                    Fanpage Facebook và đặt hàng trên Website
                                    <a href='#'>Omega</a>
                                </p>
                                <h4 class='font-weight-bold' id='luu-y'>4. Lưu ý</h4>
                                <p>
                                    Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                    trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                    <strong>090 8427608</strong> (Mr. Duy)
                                </p>
                                <p>
                                    <i>
                                        Quý khách hàng vui lòng quay phim khi unbox sản phẩm, chúng tôi sẽ không giải quyết bất kỳ khiếu nại nào nếu không có video
                                    </i>
                                </p>
                                <h4 class='font-weight-bold' id='cau-hoi'>
                                    5. Câu hỏi thường gặp
                                </h4>
                                <p>
                                    <strong>
                                        Q: Đơn gốc của mình trên 290k có được miễn ship
                                        không?
                                    </strong><br /><span>A: Có</span>
                                </p>
                                <p>
                                    <strong>
                                        Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                        gì?
                                    </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                </p>
                                <p>
                                    <strong>Q: Chương trình có tích điểm cho mình không?</strong><br /><span>A: Có</span>
                                </p>
                            </div>",

                            CreatedAt = DateTime.Now.AddDays(-5)
                        },
						new Blog
						{
				
                            Author = "Nam Lor",
                            Title = "Nhân Đôi Ưu Đãi – Mừng Xuân Giáp Thìn",
                            Thumbnail = "blog9.jpg",
                            Slug = "nhan-doi-uu-dai-mung-xuan-giap-thin",
                            ShortContent = "Gấp đôi ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc hoặc Lân Phát Tài Mini mừng Xuân Giáp Thìn. Khuyến mãi diễn ra từ 20.1 đến 2.2 với hoá đơn từ 599k và miễn phí giao hàng tận nơi",
                            ListContent = @"<ul class='menu pl-3 mt-3'>
                                                <li><a href='#thoi-gian'>1. Thời gian</a></li>
                                                <li><a href='#noi-dung'>2. Nội dung chương trình</a></li>
                                                <li><a href='#thong-tin-san-pham'>3. Thông tin sản phẩm Nhân Đôi Ưu Đãi</a></li>
                                                <li><a href='#dat-hang-hop-le'>4. Cách thức đặt hàng hợp lệ</a></li>
                                                <li><a href='#doi-tuong-tham-gia'>5. Đối tượng tham gia</a></li>
                                                <li><a href='#luu-y'>6. Lưu ý</a></li>
                                                <li><a href='#cau-hoi'>7. Câu hỏi thường gặp</a></li>
                                            </ul>",
                            Content = @"<div class='main-content'>
                                            <h4 class='font-weight-bold' id='thoi-gian'>
                                                1. Thời gian
                                            </h4>
                                            <p>
                                                Từ <strong>20.1</strong> đến hết ngày <strong>2.2</strong>
                                            </p>
                                            <h4 class='font-weight-bold' id='noi-dung'>
                                                2. Nội dung chương trình
                                            </h4>
                                            <p>
                                                Khi mua bất kì đơn hàng mô hình tại OmegaShop có giá trị từ 599.000 đ trở lên, bạn sẽ được tặng mô hình Chậu Hoa Nhỏ, Thiên Ngữ Hạc hoặc Lân Phát Tài Mini. Cụ thể như sau:
                                            <p>
                                                – Đơn hàng từ <strong>599.000 đ</strong>, được tặng 1 mô hình nhựa 3D Chậu Hoa Nhỏ (trị giá 78k)
                                            </p>
                                            <p>
                                                – Đơn hàng từ<strong>1.299.000 đ</strong> , được tặng 1 mô hình kim loại 3D Thiên Ngữ Hạc (trị giá 200k)
                                            </p>
                                            <p>
                                                – Đơn hàng từ <strong>2.499.000 đ</strong> , được tặng 1 mô hình kim loại 3D Lân Phát Tài Mini (trị giá 270k)
                                            </p>
                                            <p style='color:red'>
                                                Lưu ý: Chậu Hoa Nhỏ, Thiên Ngữ Hạc và Lân Mini là dạng Blind Box, vì vậy chúng tôi sẽ giao màu ngẫu nhiên.
                                            </p>
                                            <p>
                                                <i>Mỗi khách hàng chỉ được hưởng ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc, Lân Mini tối đa 2 sản phẩm. Ví dụ: 2x Thiên Ngữ Hạc HOẶC 2x Lân Mini HOẶC 1 Thiên Ngữ Hạc và 1 Lân Mini</i>
                                            </p>

                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                3. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                Quý khách hàng là thành viên tại OmegaShop, đặt hàng thành công tại website đối với 3 hình thức thanh toán: COD, MOMO và chuyển khoản ngân hàng
                                            </p>
                                            <h4 class='font-weight-bold' id='thong-tin-san-pham'>
                                                3. Thông tin sản phẩm NHÂN ĐÔI ƯU ĐÃI
                                            </h4>
                                            <p>
                                                Sản phẩm thuộc chương trình bao gồm: Chậu Hoa Nhỏ, Thiên Ngữ Hạc và Lân Phát Tài Mini
                                            </p>
                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                4. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                Giả sử đơn hàng gốc của quý khách sẽ mua là <strong>2.600.000 đ.</strong> Quý khách được hưởng 2 ưu đãi:
                                            </p>
                                            <p>
                                                1. Ưu đãi thuộc chương trình ưu đãi theo giá trị đơn hàng
                                            </p>
                                            <p>
                                                2. Nhân Đôi Ưu Đãi – Mừng Xuân Giáp Thìn (tặng 2 Chậu Hoa Nhỏ hoặc 2 Thiên Ngữ Hạc hoặc 1 Chậu Hoa Nhỏ + 1 Thiên Ngữ Hạc hoặc 1 Lân Mini)
                                            </p>
                                            <p>
                                                Quý khách vui lòng KHÔNG cho sản phẩm thuộc chương trình trên vào giỏ hàng , tại mục <strong>Lưu ý</strong> của bước<strong>Thanh Toán</strong> . Quý khách vui lòng ghi:Thiên Ngữ Hạc, Lân Mini…
                                            </p>
                                            <p>
                                                <strong>Lưu ý:</strong> Giá trị đơn hàng áp dụng Chương Trình Ưu Đãi sẽ bao gồm sản phẩm giảm giá
                                            </p>

                                            <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>5. Đối tượng tham gia</h4>
                                            <p>
                                                Tất cả khách hàng mua tại showroom, mua online thông qua Fanpage Facebook và đặt hàng trên Website OmegaShop
                                            </p>
                                            <p>
                                                <i>
                                                    Mỗi khách hàng chỉ được hưởng ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc, Lân Mini tối đa 2 sản phẩm. Ví dụ: 2x Thiên Ngữ Hạc HOẶC 2x Lân Mini HOẶC 1 Thiên Ngữ Hạc và 1 Lân Mini
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='luu-y'>6. Lưu ý</h4>
                                            <p>
                                                Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                                trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>
                                                    Quý khách hàng vui lòng quay phim khi unbox sản phẩm, chúng tôi sẽ không giải quyết bất kỳ khiếu nại nào nếu không có video
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='cau-hoi'>
                                                7. Câu hỏi thường gặp
                                            </h4>
                                            <p>
                                                <strong>
                                                    Q: Đơn gốc của mình trên 290k có được miễn ship
                                                    không?
                                                </strong><br /><span>A: Có</span>
                                            </p>
                                            <p>
                                                <strong>
                                                    Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                                    gì?
                                                </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                            </p>
                                            <p>
                                                <strong>Q: Chương trình có tích điểm cho mình không?</strong><br /><span>A: Có</span>
                                            </p>
                                        </div>",
                            CreatedAt = DateTime.Now.AddDays(-4)
                        },
						new Blog
						{
			
							Author = "Phát bé",
                            Title = "Mua kèm deal sốc - giảm đến 70%",
                            Thumbnail = "blog10.jpg",
                            Slug = "mua-kem-deal-soc-giam-den-70",
                            ListContent = @"<ul class='menu pl-3 mt-3'>
                                                <li><a href='#thoi-gian'>1. Thời gian</a></li>
                                                <li><a href='#noi-dung'>2. Nội dung chương trình</a></li>
                                                <li><a href='#dat-hang-hop-le'>3. Cách thức đặt hàng hợp lệ</a></li>
                                                <li><a href='#doi-tuong-tham-gia'>4. Đối tượng tham gia</a></li>
                                                <li><a href='#luu-y'>5. Lưu ý</a></li>
                                                <li><a href='#cau-hoi'>6. Câu hỏi thường gặp</a></li>
                                            </ul>",
                            ShortContent = "Mua kèm deal sốc hơn 130 sản phẩm HOT giảm giá đến 70% khi mua sắm với hóa đơn từ 299K . Áp dụng từ 7.1 ~ 15/1. FREESHIP với đơn từ 290K",
                            Content = @"<div class='main-content'>
                                            <h4 class='font-weight-bold' id='thoi-gian'>1. Thời gian</h4>
                                            <p>
                                                Từ <strong>7.1</strong> đến hết ngày <strong>15.1</strong>
                                            </p>
                                            <h4 class='font-weight-bold' id='noi-dung'>
                                                2. Nội dung chương trình
                                            </h4>
                                            <p>
                                                Khi mua sắm với hóa đơn từ <strong>299k</strong>, quý khách sẽ
                                                được tham gia chương trình Mua Kèm Deal Sốc hơn 130 sản phẩm
                                                HOT với giá giảm đến 70%
                                            </p>
                                            <p>
                                                Danh sách sản phẩm thuộc chương trình
                                                <strong>Deal Sốc 2025</strong> quý khách xem tại đây:
                                                <a href='#'>https://omega.vn/collections/deal-soc-2024/</a>
                                            </p>
                                            <p class='font-weight-bold'>Cụ thể như sau:</p>
                                            <p>
                                                - Hóa Đơn (HD) từ <strong>299k</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 99k</span> chỉ với giá
                                                <strong>99k</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>499K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 299K</span> chỉ với giá
                                                <strong>299K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>699K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 499K</span> chỉ với giá
                                                <strong>499K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>899K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 699K</span> chỉ với giá
                                                <strong>699K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>1099K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 899K</span> chỉ với giá
                                                <strong>899K</strong>
                                            </p>
                                            <p>
                                                - HĐ từ <strong>1499K</strong>: Mua 1 sản phẩm có tag
                                                <span class='text-primary'>Deal Sốc 1099K</span> chỉ với giá
                                                <strong>1099K</strong>
                                            </p>
                                            <p>
                                                <i>Áp dụng mua nhiều sản phẩm Deal Sốc trên cùng 1 hóa đơn</i>
                                            </p>
                                            <p><i>Không giới hạn số lần mua sắm</i></p>
                                            <p><i>Áp dụng FREESHIP đối với hóa đơn từ 290K</i></p>
                                            <p>
                                                <i>
                                                    Không áp dụng sản phẩm Deal Sốc đối với các chương trình
                                                    khuyến mãi khác. Quyền quyết định cuối cùng thuộc về
                                                    Omega
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                3. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                <strong>Ví dụ: </strong>Khách hàng mua 3 sản phẩm trong giỏ
                                                hàng (sản phẩm A = 400.000đ, sản phẩm B = 600.00đ, sản phẩm C
                                                = 500.000đ)
                                            </p>
                                            <p>
                                                Tổng hóa đơn: 1.500.000đ, áp voucher giảm 4% (60K) => Tổng
                                                thanh toán: 1.440.000 đ
                                            </p>
                                            <p>
                                                Quý khách hàng được tham gia chương trình
                                                <strong>Deal Sốc 2024</strong> linh hoạt như sau:
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 1: mua 4 sản phẩm trong danh sách Deal Sốc 99K,
                                                tổng đơn: 1.440.000 đ + (99.000 * 4) = 1.836.000đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 2: mua 2 sản phẩm trong danh sách Deal Sốc 299K và
                                                1 sản phẩm trong danh sách Deal Sốc 99K, tổng đơn: 1.440.000 đ
                                                + (299.000 đ * 2) + 99.000 đ = 2.137.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 3: mua 2 sản phẩm trong danh sách Deal Sốc 499k,
                                                tổng đơn: 1.440.000 đ + (499.000 đ * 2) = 2.438.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 4: mua 1 sản phẩm trong danh sách Deal Sốc 699K và
                                                1 sản phẩm trong danh sách Deal Sốc 299K, tổng đơn: 1.440.000
                                                đ + 699.000 đ + 299.000 đ = 2.438.000 đ
                                            </p>
                                            <p style='color: #16a085'>
                                                - Lựa chọn 5: mua 1 sản phẩm trong danh sách Deal Sốc 899k và
                                                1 sản phẩm trong danh sách Deal Sốc 99K, tổng đơn: 1.440.000 đ
                                                + 899.000 đ + 99.000 đ = 2.438.000 đ
                                            </p>
                                            <p>
                                                Quý khách có thể tự linh động kết hợp tùy vào giá trị hóa đơn,
                                                có thể mua 1 hoặc nhiều sản phẩm Deal Sốc.
                                            </p>
                                            <p>
                                                Trong trường hợp quý khách hàng gặp khó khăn hoặc chưa nắm rõ
                                                về chương trình. Vui lòng liên hệ Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>Đối với hóa đơn từ 290K, quý khách sẽ được FREESHIP</i>
                                            </p>
                                            <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>
                                                4. Đối tượng tham gia
                                            </h4>
                                            <p>
                                                Tất cả khách hàng mua tại showroom, mua online thông qua
                                                Fanpage Facebook và đặt hàng trên Website
                                                <a href='#'>https://omega.vn</a>
                                            </p>
                                            <h4 class='font-weight-bold' id='luu-y'>5. Lưu ý</h4>
                                            <p>
                                                Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                                trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>
                                                    Không áp dụng đổi trả, bảo hành đối với sản phẩm tham gia
                                                    chương trình <strong>Deal Sốc 2024</strong>
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='cau-hoi'>
                                                6. Câu hỏi thường gặp
                                            </h4>
                                            <p>
                                                <strong>
                                                    Q: Đơn gốc của mình trên 290k có được miễn ship
                                                    không?
                                                </strong><br /><span>A: Có</span>
                                            </p>
                                            <p>
                                                <strong>
                                                    Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                                    gì?
                                                </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                            </p>
                                            <p>
                                                <strong>Q: Chương trình có tích điểm AP cho mình không?</strong><br /><span>A: Có</span>
                                            </p>
                                        </div>",
                            CreatedAt = DateTime.Now.AddDays(-3)
                        },
						new Blog
						{

							Author = "Anh Ánh",
                            Title = "[BLACK FRIDAY] GIẢM ĐẾN 70% - NGẬP TRÀN ƯU ĐÃI",
                            Thumbnail = "blog11.jpg",
                            Slug = "black-friday-giam-den-70-ngap-tran-uu-dai",
                            ShortContent = "Giảm giá đến 70% toàn bộ mô hình lắp ráp 3D khi đặt hàng thành công tại website OmegaShop. FREESHIP với đơn từ 290K",
                            ListContent = @"<ul class='menu pl-3 mt-3'>              
                                        <li><a href='#noi-dung'>1. Nội dung chương trình</a></li>
                                        <li><a href='#dat-hang-hop-le'>2. Cách thức đặt hàng hợp lệ</a></li>
                                        <li><a href='#doi-tuong-tham-gia'>3. Đối tượng tham gia</a></li>
                                        <li><a href='#luu-y'>4. Lưu ý</a></li>
                                        <li><a href='#cau-hoi'>5. Câu hỏi thường gặp</a></li>
                                    </ul>",
                            Content = @"<div class='main-content'>
                                <h4 class='font-weight-bold' id='noi-dung'>
                                    1. Nội dung chương trình
                                </h4>
                                <p>
                                    Giảm giá đến <strong>70%</strong>, với tất cả sản phẩm  tại OmegaShop. Giá sản phẩm tại website là giá đã giảm.
                                </p>
                                <p>
                                    Xem toàn bộ mô hình tại đây:
                                    <a asp-controller='Product' asp-action='Index'>Sản phẩm</a>
                                </p>
                                <p>
                                    Áp dụng
                                    <strong>FREESHIP</strong> đối với hóa đơn từ<strong>290K</strong>

                                </p>
                                <p>
                                    <i>Không áp dụng đối với các chương trình khuyến mãi khác. Quyền quyết định cuối cùng thuộc về Art Puzzle</i>
                                </p>

                                <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                    2. Cách thức đặt hàng hợp lệ
                                </h4>
                                <p>
                                    Quý khách hàng là thành viên tại OmegaShop, đặt hàng thành công tại website đối với 3 hình thức thanh toán: COD, MOMO và chuyển khoản ngân hàng
                                </p>

                                <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>
                                    3. Đối tượng tham gia
                                </h4>
                                <p>
                                    Tất cả khách hàng mua tại showroom, mua online thông qua
                                    Fanpage Facebook và đặt hàng trên Website
                                    <a href='#'>Omega</a>
                                </p>
                                <h4 class='font-weight-bold' id='luu-y'>4. Lưu ý</h4>
                                <p>
                                    Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                    trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                    <strong>090 8427608</strong> (Mr. Duy)
                                </p>
                                <p>
                                    <i>
                                        Quý khách hàng vui lòng quay phim khi unbox sản phẩm, chúng tôi sẽ không giải quyết bất kỳ khiếu nại nào nếu không có video
                                    </i>
                                </p>
                                <h4 class='font-weight-bold' id='cau-hoi'>
                                    5. Câu hỏi thường gặp
                                </h4>
                                <p>
                                    <strong>
                                        Q: Đơn gốc của mình trên 290k có được miễn ship
                                        không?
                                    </strong><br /><span>A: Có</span>
                                </p>
                                <p>
                                    <strong>
                                        Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                        gì?
                                    </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                </p>
                                <p>
                                    <strong>Q: Chương trình có tích điểm cho mình không?</strong><br /><span>A: Có</span>
                                </p>
                            </div>",

                            CreatedAt = DateTime.Now.AddDays(-2)
                        },
						new Blog
						{
							Author = "Atus",
                            Title = "Nhân Đôi Ưu Đãi – Mừng Xuân Giáp Thìn",
                            Thumbnail = "blog12.jpg",
                            Slug = "nhan-doi-uu-dai-mung-xuan-giap-thin",
                            ShortContent = "Gấp đôi ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc hoặc Lân Phát Tài Mini mừng Xuân Giáp Thìn. Khuyến mãi diễn ra từ 20.1 đến 2.2 với hoá đơn từ 599k và miễn phí giao hàng tận nơi",
                            ListContent = @"<ul class='menu pl-3 mt-3'>
                                                <li><a href='#thoi-gian'>1. Thời gian</a></li>
                                                <li><a href='#noi-dung'>2. Nội dung chương trình</a></li>
                                                <li><a href='#thong-tin-san-pham'>3. Thông tin sản phẩm Nhân Đôi Ưu Đãi</a></li>
                                                <li><a href='#dat-hang-hop-le'>4. Cách thức đặt hàng hợp lệ</a></li>
                                                <li><a href='#doi-tuong-tham-gia'>5. Đối tượng tham gia</a></li>
                                                <li><a href='#luu-y'>6. Lưu ý</a></li>
                                                <li><a href='#cau-hoi'>7. Câu hỏi thường gặp</a></li>
                                            </ul>",
                            Content = @"<div class='main-content'>
                                            <h4 class='font-weight-bold' id='thoi-gian'>
                                                1. Thời gian
                                            </h4>
                                            <p>
                                                Từ <strong>20.1</strong> đến hết ngày <strong>2.2</strong>
                                            </p>
                                            <h4 class='font-weight-bold' id='noi-dung'>
                                                2. Nội dung chương trình
                                            </h4>
                                            <p>
                                                Khi mua bất kì đơn hàng mô hình tại OmegaShop có giá trị từ 599.000 đ trở lên, bạn sẽ được tặng mô hình Chậu Hoa Nhỏ, Thiên Ngữ Hạc hoặc Lân Phát Tài Mini. Cụ thể như sau:
                                            <p>
                                                – Đơn hàng từ <strong>599.000 đ</strong>, được tặng 1 mô hình nhựa 3D Chậu Hoa Nhỏ (trị giá 78k)
                                            </p>
                                            <p>
                                                – Đơn hàng từ<strong>1.299.000 đ</strong> , được tặng 1 mô hình kim loại 3D Thiên Ngữ Hạc (trị giá 200k)
                                            </p>
                                            <p>
                                                – Đơn hàng từ <strong>2.499.000 đ</strong> , được tặng 1 mô hình kim loại 3D Lân Phát Tài Mini (trị giá 270k)
                                            </p>
                                            <p style='color:red'>
                                                Lưu ý: Chậu Hoa Nhỏ, Thiên Ngữ Hạc và Lân Mini là dạng Blind Box, vì vậy chúng tôi sẽ giao màu ngẫu nhiên.
                                            </p>
                                            <p>
                                                <i>Mỗi khách hàng chỉ được hưởng ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc, Lân Mini tối đa 2 sản phẩm. Ví dụ: 2x Thiên Ngữ Hạc HOẶC 2x Lân Mini HOẶC 1 Thiên Ngữ Hạc và 1 Lân Mini</i>
                                            </p>

                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                3. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                Quý khách hàng là thành viên tại OmegaShop, đặt hàng thành công tại website đối với 3 hình thức thanh toán: COD, MOMO và chuyển khoản ngân hàng
                                            </p>
                                            <h4 class='font-weight-bold' id='thong-tin-san-pham'>
                                                3. Thông tin sản phẩm NHÂN ĐÔI ƯU ĐÃI
                                            </h4>
                                            <p>
                                                Sản phẩm thuộc chương trình bao gồm: Chậu Hoa Nhỏ, Thiên Ngữ Hạc và Lân Phát Tài Mini
                                            </p>
                                            <h4 class='font-weight-bold' id='dat-hang-hop-le'>
                                                4. Cách thức đặt hàng hợp lệ
                                            </h4>
                                            <p>
                                                Giả sử đơn hàng gốc của quý khách sẽ mua là <strong>2.600.000 đ.</strong> Quý khách được hưởng 2 ưu đãi:
                                            </p>
                                            <p>
                                                1. Ưu đãi thuộc chương trình ưu đãi theo giá trị đơn hàng
                                            </p>
                                            <p>
                                                2. Nhân Đôi Ưu Đãi – Mừng Xuân Giáp Thìn (tặng 2 Chậu Hoa Nhỏ hoặc 2 Thiên Ngữ Hạc hoặc 1 Chậu Hoa Nhỏ + 1 Thiên Ngữ Hạc hoặc 1 Lân Mini)
                                            </p>
                                            <p>
                                                Quý khách vui lòng KHÔNG cho sản phẩm thuộc chương trình trên vào giỏ hàng , tại mục <strong>Lưu ý</strong> của bước<strong>Thanh Toán</strong> . Quý khách vui lòng ghi:Thiên Ngữ Hạc, Lân Mini…
                                            </p>
                                            <p>
                                                <strong>Lưu ý:</strong> Giá trị đơn hàng áp dụng Chương Trình Ưu Đãi sẽ bao gồm sản phẩm giảm giá
                                            </p>

                                            <h4 class='font-weight-bold' id='doi-tuong-tham-gia'>5. Đối tượng tham gia</h4>
                                            <p>
                                                Tất cả khách hàng mua tại showroom, mua online thông qua Fanpage Facebook và đặt hàng trên Website OmegaShop
                                            </p>
                                            <p>
                                                <i>
                                                    Mỗi khách hàng chỉ được hưởng ưu đãi tặng Chậu Hoa Nhỏ, Thiên Ngữ Hạc, Lân Mini tối đa 2 sản phẩm. Ví dụ: 2x Thiên Ngữ Hạc HOẶC 2x Lân Mini HOẶC 1 Thiên Ngữ Hạc và 1 Lân Mini
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='luu-y'>6. Lưu ý</h4>
                                            <p>
                                                Quý khách hàng vui lòng liên hệ nhân viên để kiểm tra tình
                                                trạng còn hàng của các sản phẩm thông qua qua Hotline:
                                                <strong>090 8427608</strong> (Mr. Duy)
                                            </p>
                                            <p>
                                                <i>
                                                    Quý khách hàng vui lòng quay phim khi unbox sản phẩm, chúng tôi sẽ không giải quyết bất kỳ khiếu nại nào nếu không có video
                                                </i>
                                            </p>
                                            <h4 class='font-weight-bold' id='cau-hoi'>
                                                7. Câu hỏi thường gặp
                                            </h4>
                                            <p>
                                                <strong>
                                                    Q: Đơn gốc của mình trên 290k có được miễn ship
                                                    không?
                                                </strong><br /><span>A: Có</span>
                                            </p>
                                            <p>
                                                <strong>
                                                    Q: Mình muốn tư vấn trực tiếp, hotline của bạn là
                                                    gì?
                                                </strong><br /><span>A: Hotline: <strong>090 8427608</strong> (Mr. Duy)</span>
                                            </p>
                                            <p>
                                                <strong>Q: Chương trình có tích điểm cho mình không?</strong><br /><span>A: Có</span>
                                            </p>
                                        </div>",
                            CreatedAt = DateTime.Now.AddDays(-4)
                        }
						);
					context.SaveChanges();
				}

				if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role
                        {
                            Name = "Quản trị viên",
                            Description = "Có thể quản lý tài khoản và có toàn quyền trên hệ thống"
                        },
                        new Role
                        {
                            Name = "Nhân viên bán hàng",
                            Description = "Quản lý sản phẩm, danh mục, đơn hàng, liên hệ."
                        },
                        new Role
                        {
                            Name = "Khách hàng",
                            Description = "Các quyền ở client"
                        }
                        );
                    context.SaveChanges();
                }
                if (!context.Accounts.Any())
                {
                    context.Accounts.AddRange(
                        new Account
                        {
                            Fullname = "Đỗ Đình Duy",
                            Gender = true,
                            Email = "duy2004.gi@gmail.com",
                            Phone = "0123456789",
                            Username = "dduy2004",
                            Password = "123456",
                            Address = "1/4 đường số 12, Phường Hiệp Bình Chánh, TP. Thủ Đức, TP. HCM",
                            RoleId = 1,
                            Status = 1
                        },
                        new Account
                        {
                            Fullname = "Lê Bá Hoàng Ánh",
                            Gender = true,
                            Email = "hoanganh2004@gmail.com",
                            Phone = "0123456789",
                            Username = "honganhle",
                            Password = "123456",
                            Address = "1/4 đường số 12, Phường Hiệp Bình Chánh, TP. Thủ Đức, TP. HCM",
                            RoleId = 1,
                            Status = 1
                        },
                        new Account
                        {
                            Fullname = "Nguyễn Phương Nam",
                            Gender = true,
                            Email = "phuongnam8481@gmail.com",
                            Phone = "0123456789",
                            Username = "phuongnam1124",
                            Password = "123456",
                            Address = "66/175 Xô Viết Nghệ Tĩnh, P.21, Q. Bình Thạnh, TP. Hồ Chí Minh",
                            RoleId = 2,
                            Status = 2
                        },
                        new Account
                        {
                            Fullname = "Huỳnh Anh Tú",
                            Gender = true,
                            Email = "emtu@gmail.com",
                            Phone = "0123456789",
                            Username = "anhtuuuuu",
                            Password = "123456",
                            Address = "14/331 Nguyễn Văn Cừ, P.4, Q.8, TP. Hồ Chí Minh",
                            RoleId = 2,
                            Status = 2
                        },
                        new Account
                        {
                            Fullname = "Nguyễn Duy Thanh Tú",
                            Gender = true,
                            Email = "taygu@gmail.com",
                            Phone = "0123456789",
                            Username = "gaynhatvn",
                            Password = "123456",
                            Address = "23/119 Phan Văn Trị, P.8, Q.2, TP. Hồ Chí Minh",
                            RoleId = 3,
                            Status = 3
                        },
                        new Account
                        {
                            Fullname = "Nguyễn Tấn Phát",
                            Gender = true,
                            Email = "ntphat@gmail.com",
                            Phone = "0123456789",
                            Username = "ntphat",
                            Password = "123456",
                            Address = "32/111 Nguyễn Thị Minh Khai, P.10, Q.1 , TP. Hồ Chí Minh",
                            RoleId = 3,
                            Status = 3
                        }
                        );
                    context.SaveChanges();
                }
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category
                        {
                            Name = "Tàu chiến",
                            Description = "Mô hình tàu chiến",
                            Slug = "tau-chien",
                            Status = 1
                        },
                        new Category
                        {
                            Name = "Súng",
                            Description = "Mô hình súng",
                            Slug = "sung",
                            Status = 1
                        },
                        new Category
                        {
                            Name = "Harry Potter",
                            Description = "Mô hình harry potter",
                            Slug = "harry-potter",
                            Status = 1
                        },
                        new Category
                        {
                            Name = "Nhà Dollhouse",
                            Description = "Mô hình nhà dollhouse",
                            Slug = "nha-dollhouse",
                            Status = 1
                        },
                        new Category
                        {
                            Name = "Máy bay",
                            Description = "Mô hình máy bay",
                            Slug = "may-bay",
                            Status = 1
                        },
                        new Category
                        {
                            Name = "Khủng long rồng",
                            Description = "Mô hình khủng long rồng",
                            Slug = "khung-long-rong",
                            Status = 1
                        },
                        new Category
                        {
                            Name = "Động vật",
                            Description = "Mô hình động vật",
                            Slug = "dong-vat",
                            Status = 1
                        }
                        );
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            ProductCode = "SP001",
                            Name = "Mô Hình Giấy 3D Lắp Ráp CubicFun Con Hươu Cao Cổ P857h (43 mảnh, Giraffe) - SP001",
                            Thumbnail = "mo-hinh-giay-3d-lap-rap-cubicfun-con-huou-cao-co-p857h-43-manh-giraffe-sp001-0.jpg",
                            Price = 215000,
                            DiscountRate = 31,
                            Slug = "mo-hinh-giay-3d-lap-rap-cubicfun-con-huou-cao-co-p857h-43-manh-giraffe-sp001",
                            Stock = 100,
                            Description = "<p><strong>Mô Hình Giấy 3D Lắp Ráp CubicFun Con Hươu Cao Cổ P857h (43 mảnh, Giraffe) - SP001</strong></p><ul><li>Mã sản phẩm:&nbsp;SP001</li><li>Chất liệu: Xốp EPS và giấy</li><li>Kích thước:&nbsp;&nbsp;31.5×17.8×35cm</li><li>Độ khó: 2/10</li><li>Mảnh ghép: 43</li><li>Hãng sản xuất: CubicFun</li><li>Phù hợp độ tuổi: 8+</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-giay-3d\">Mô hình giấy 3D</a> với cách lắp ráp đơn giản: tách ra và ghép vào, không cần cắt và keo dán. Quan trọng hơn, người chơi có thể tháo rời mô hình, trả các chi tiết về lại miếng 2D và cất đi cho lần chơi sau</p><p><strong>ĐẶC ĐIỂM NỔI BẬC</strong></p><p>⭐ Màu sắc đẹp mắt: Màu sắc trang trí đẹp và trang nhã cho bé sự thích thú khi chơi.&nbsp;</p><p>⭐ Mô hình vững chãi: Tổng quan mô hình sau khi ráp rất cứng cáp và đẹp mắt. Mô hình có thể dựng ở không gian phòng trong thời gian dài mà không hề bị biến dạng.&nbsp;</p><p>⭐ Rèn luyện sự khéo léo, tỉ mỉ: Trong suốt quá trình mày mò lắp ráp, bé sẽ tập tính kiên trì, nhẫn nại, hiểu được giá trị lao động từ những thứ mà bé làm ra.&nbsp;</p><p>⭐ Kích thích tư duy sáng tạo: Bộ xếp hình 3D giúp bé luyện trí nhớ, tăng khả năng tư duy và phát triển trí não toàn diện. Hơn nữa, đồ chơi xếp hình còn có nhiều sản phẩm cùng chủng loại cho bé thỏa mãn niềm đam mê sưu tập.&nbsp;</p><p>⭐ Gắn kết gia đình: Hãy thử tưởng tượng xem vào một buổi tối hay cuối tuần nào đó, cả nhà cùng xếp hình, cùng cười đùa, chuyện trò rôm rả… không khí gia đình thật đầm ấm, vui vẻ biết bao.</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh giấy&nbsp;ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ.&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p><strong>THÔNG TIN THƯƠNG HIỆU&nbsp;</strong></p><p>Là một doanh nghiệp đồ chơi hàng đầu chuyên nghiên cứu, phát triển, thiết kế, sản xuất và tiếp thị về đồ chơi lắp ghép Puzzle 3D mang thương hiệu CubicFun. Với số lượng bán hàng lớn nhất trong ngành công nghiệp Puzzle 3D, các sản phẩm CubicFun được bán cho hơn 80 quốc gia trên toàn thế giới bao gồm Châu Âu, Mỹ, Nga, và Đông Nam Á và các đối tác có uy tín cao như Toys R Us, Walmart, Carrefour, Auchan , Tesco, và Barnes &amp; Noble. Ở Việt Nam, với tiêu chí đem lại giá trị về văn hóa, giáo dục, giải trí và trưng bày cho mọi nhà, cũng như thông qua đồ chơi mô hình, con người sẽ sáng tạo hơn và hạnh phúc hơn, CubicFun ngày càng được người tiêu dùng trong nước ưa chuộng.</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d #mohinhnhua3d #mohinhnonlego #lego #mohinh3dnhua #mohinhgiay3d #cubicfun&nbsp;</p>",
                            CategoryId = 7,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP002",
                            Name = "Mô Hình Giấy 3D Lắp Ráp CubicFun Thế Giới Bắc Cực DS0983h (73 mảnh, National Geographic Arctic) - SP002",
                            Thumbnail = "mo-hinh-giay-3d-lap-rap-cubicfun-the-gioi-bac-cuc-ds0983h-73-manh-national-geographic-arctic-sp002-0.jpg",
                            Price = 330000,
                            DiscountRate = 6,
                            Slug = "mo-hinh-giay-3d-lap-rap-cubicfun-the-gioi-bac-cuc-ds0983h-73-manh-national-geographic-arctic-sp002",
                            Stock = 90,
                            Description = "<p><strong>Mô Hình Giấy 3D Lắp Ráp CubicFun Thế Giới Bắc Cực DS0983h (73 mảnh, National Geographic Arctic) - SP002</strong></p><ul><li>Mã sản phẩm:&nbsp;SP002</li><li>Chất liệu: Xốp EPS và giấy</li><li>Kích thước:&nbsp;44.5×26.7×21.7cm</li><li>Độ khó: 4/10</li><li>Mảnh ghép: 73</li><li>Hãng sản xuất: CubicFun</li><li>Phù hợp độ tuổi: 8+</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-giay-3d\">Mô hình giấy 3D</a> với cách lắp ráp đơn giản: tách ra và ghép vào, không cần cắt và keo dán. Quan trọng hơn, người chơi có thể tháo rời mô hình, trả các chi tiết về lại miếng 2D và cất đi cho lần chơi sau</p><p><strong>ĐẶC ĐIỂM NỔI BẬC</strong></p><p>⭐ Màu sắc đẹp mắt: Màu sắc trang trí đẹp và trang nhã cho bé sự thích thú khi chơi.&nbsp;</p><p>⭐ Mô hình vững chãi: Tổng quan mô hình sau khi ráp rất cứng cáp và đẹp mắt. Mô hình có thể dựng ở không gian phòng trong thời gian dài mà không hề bị biến dạng.&nbsp;</p><p>⭐ Rèn luyện sự khéo léo, tỉ mỉ: Trong suốt quá trình mày mò lắp ráp, bé sẽ tập tính kiên trì, nhẫn nại, hiểu được giá trị lao động từ những thứ mà bé làm ra.&nbsp;</p><p>⭐ Kích thích tư duy sáng tạo: Bộ xếp hình 3D giúp bé luyện trí nhớ, tăng khả năng tư duy và phát triển trí não toàn diện. Hơn nữa, đồ chơi xếp hình còn có nhiều sản phẩm cùng chủng loại cho bé thỏa mãn niềm đam mê sưu tập.&nbsp;</p><p>⭐ Gắn kết gia đình: Hãy thử tưởng tượng xem vào một buổi tối hay cuối tuần nào đó, cả nhà cùng xếp hình, cùng cười đùa, chuyện trò rôm rả… không khí gia đình thật đầm ấm, vui vẻ biết bao.</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh giấy&nbsp;ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ.&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p><strong>THÔNG TIN THƯƠNG HIỆU&nbsp;</strong></p><p>Là một doanh nghiệp đồ chơi hàng đầu chuyên nghiên cứu, phát triển, thiết kế, sản xuất và tiếp thị về đồ chơi lắp ghép Puzzle 3D mang thương hiệu CubicFun. Với số lượng bán hàng lớn nhất trong ngành công nghiệp Puzzle 3D, các sản phẩm CubicFun được bán cho hơn 80 quốc gia trên toàn thế giới bao gồm Châu Âu, Mỹ, Nga, và Đông Nam Á và các đối tác có uy tín cao như Toys R Us, Walmart, Carrefour, Auchan , Tesco, và Barnes &amp; Noble. Ở Việt Nam, với tiêu chí đem lại giá trị về văn hóa, giáo dục, giải trí và trưng bày cho mọi nhà, cũng như thông qua đồ chơi mô hình, con người sẽ sáng tạo hơn và hạnh phúc hơn, CubicFun ngày càng được người tiêu dùng trong nước ưa chuộng.</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d #mohinhnhua3d #mohinhnonlego #lego #mohinh3dnhua #mohinhgiay3d #cubicfun&nbsp;</p>",
                            CategoryId = 7,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP003",
                            Name = "Mô Hình Kim Loại Lắp Ráp 3D Piececool Thiết Giáp Hạm USS Missouri HP096-S - SP003",
                            Thumbnail = "mo-hinh-kim-loai-lap-rap-3d-piececool-thiet-giap-ham-uss-missouri-sp003-0.jpg",
                            Price = 365000,
                            DiscountRate = 10,
                            Slug = "mo-hinh-kim-loai-lap-rap-3d-piececool-thiet-giap-ham-uss-missouri-sp003",
                            Stock = 99,
                            Description = "<p><strong>Mô Hình Kim Loại Lắp Ráp 3D Piececool Thiết Giáp Hạm USS Missouri HP096-S – SP003</strong></p><ul><li>Mã sản phẩm:&nbsp;SP003</li><li>Chất liệu: Thép không rỉ inox 430, đồng thau</li><li>Kích thước (Dài*Rộng*Cao):&nbsp;30.5 X 3.2 X 7.3CM</li><li>Độ khó: 6/10</li><li>Mảnh ghép: 155</li><li>Hãng sản xuất: Piececool</li><li>Phù hợp độ tuổi: 14+</li><li>Dụng cụ cần thiết: Kìm cắt, kìm nhọn, nhíp, bộ uốn</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-kim-loai-3d\">MÔ HÌNH KIM LOẠI 3D</a> được cộng đồng quốc tế đánh giá là trò chơi mang tính sáng tạo bậc nhất trong những năm gần đây. Thiết kế mang tính sáng tạo, độc đáo và độ chi tiết đáng kinh ngạc là những nét nổi bật tạo nên sức hút mạnh mẽ, khơi dậy niềm đam mê mô hình trong mỗi người chơi khi chọn mua sản phẩm. Hãy để trẻ có thêm sự lựa chọn vui chơi, tự ráp những bộ mô hình thép 3D độc đáo thay vì dành hàng giờ cho chiếc máy tính, điện thoại.</p><p><strong>SỰ VƯỢT TRỘI CỦA MÔ HÌNH KIM LOẠI 3D&nbsp;</strong></p><p>⭐ Thiết kế sáng tạo, độc đáo từ chú chuồn chuồn dễ thương, gần gũi đến chiếc tàu chiến từng làm bá chủ cả vùng biển rộng. ⭐ Độ chi tiết đáng kinh ngạc: được khắc bằng laze hiện đại cùng độ chi tiết cao từ các nhà thiết kế tài năng, mô hình có độ chạm khắc tốt, chi tiết rất rõ ràng. Đồng thời có tính dẻo và bền hơn chất liệu giấy hay gỗ.&nbsp;</p><p>⭐ Màu sắc trung thực: nguyên thuỷ màu bạc và có thể nhiều màu&nbsp;</p><p>⭐ Nhỏ gọn, dễ bảo quản: đại đa số các mẫu đều có kích thước vừa phải, đồng thời sử dụng chất liệu thép không gỉ nên mô hình hoàn toàn bền bỉ với thời gian và không yêu cầu gì quá khắt khe khi bảo quản.&nbsp;</p><p>⭐ Tính giải trí cao: cảm giác lắp ráp vài tiếng liên tục để được thành phẩm sẽ làm bạn rất thích thú</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên sử dụng các dụng cụ hỗ trợ để quá trình lắp ráp nhanh, thuận tiện và chính xác hơn&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh thép 3D&nbsp;</p><p>⭐ Bạn sử dụng kềm cắt linh kiện hoặc kềm cắt da tay phụ nữ để tách mảnh thép ra&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Ký hiệu hình tròn: bạn gập khớp nối 90 độ&nbsp;</p><p>⭐ Ký hiệu hình tam giác: bạn xoắn khớp nối 90 độ&nbsp;</p><p>⭐ Ngoài ra còn có các bộ phần cần uốn tròn. Bạn nên sử dụng bộ dụng cụ uốn kim loại 3D hoặc dụng cụ tại nhà&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d</p>",
                            CategoryId = 1,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP004",
                            Name = "Mô Hình Giấy 3D Lắp Ráp CubicFun Con Cú Tuyết DS1079h (62 mảnh, Snowy Owl) - SP004",
                            Thumbnail = "mo-hinh-giay-3d-lap-rap-cubicfun-con-cu-tuyet-ds1079h-62-manh-snowy-owl-sp004-0.jpg",
                            Price = 315000,
                            DiscountRate = 1,
                            Slug = "mo-hinh-giay-3d-lap-rap-cubicfun-con-cu-tuyet-ds1079h-62-manh-snowy-owl-sp004",
                            Stock = 60,
                            Description = "<p><strong>Mô Hình Giấy 3D Lắp Ráp CubicFun Con Cú Tuyết DS1079h (62 mảnh, Snowy Owl) - SP004</strong></p><ul><li>Mã sản phẩm:&nbsp;<strong>SP004</strong></li><li>Chất liệu: Xốp EPS và giấy</li><li>Kích thước:&nbsp;17&nbsp;x 17.3 x 24.6 CM&nbsp;</li><li>Độ khó: 3/10</li><li>Mảnh ghép: 62</li><li>Hãng sản xuất: CubicFun</li><li>Phù hợp độ tuổi: 8+</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-giay-3d\">Mô hình giấy 3D</a> với cách lắp ráp đơn giản: tách ra và ghép vào, không cần cắt và keo dán. Quan trọng hơn, người chơi có thể tháo rời mô hình, trả các chi tiết về lại miếng 2D và cất đi cho lần chơi sau</p><p><strong>ĐẶC ĐIỂM NỔI BẬC</strong></p><p>⭐ Màu sắc đẹp mắt: Màu sắc trang trí đẹp và trang nhã cho bé sự thích thú khi chơi.&nbsp;</p><p>⭐ Mô hình vững chãi: Tổng quan mô hình sau khi ráp rất cứng cáp và đẹp mắt. Mô hình có thể dựng ở không gian phòng trong thời gian dài mà không hề bị biến dạng.&nbsp;</p><p>⭐ Rèn luyện sự khéo léo, tỉ mỉ: Trong suốt quá trình mày mò lắp ráp, bé sẽ tập tính kiên trì, nhẫn nại, hiểu được giá trị lao động từ những thứ mà bé làm ra.&nbsp;</p><p>⭐ Kích thích tư duy sáng tạo: Bộ xếp hình 3D giúp bé luyện trí nhớ, tăng khả năng tư duy và phát triển trí não toàn diện. Hơn nữa, đồ chơi xếp hình còn có nhiều sản phẩm cùng chủng loại cho bé thỏa mãn niềm đam mê sưu tập.&nbsp;</p><p>⭐ Gắn kết gia đình: Hãy thử tưởng tượng xem vào một buổi tối hay cuối tuần nào đó, cả nhà cùng xếp hình, cùng cười đùa, chuyện trò rôm rả… không khí gia đình thật đầm ấm, vui vẻ biết bao.</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh giấy&nbsp;ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ.&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p><strong>THÔNG TIN THƯƠNG HIỆU&nbsp;</strong></p><p>Là một doanh nghiệp đồ chơi hàng đầu chuyên nghiên cứu, phát triển, thiết kế, sản xuất và tiếp thị về đồ chơi lắp ghép Puzzle 3D mang thương hiệu CubicFun. Với số lượng bán hàng lớn nhất trong ngành công nghiệp Puzzle 3D, các sản phẩm CubicFun được bán cho hơn 80 quốc gia trên toàn thế giới bao gồm Châu Âu, Mỹ, Nga, và Đông Nam Á và các đối tác có uy tín cao như Toys R Us, Walmart, Carrefour, Auchan , Tesco, và Barnes &amp; Noble. Ở Việt Nam, với tiêu chí đem lại giá trị về văn hóa, giáo dục, giải trí và trưng bày cho mọi nhà, cũng như thông qua đồ chơi mô hình, con người sẽ sáng tạo hơn và hạnh phúc hơn, CubicFun ngày càng được người tiêu dùng trong nước ưa chuộng.</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d #mohinhnhua3d #mohinhnonlego #lego #mohinh3dnhua #mohinhgiay3d #cubicfun&nbsp;</p>",
                            CategoryId = 7,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP005",
                            Name = "Mô Hình Kim Loại 3D Lắp Ráp Piececool Tuần Dương Hạm HMS Hood P209-SR - SP005",
                            Thumbnail = "mo-hinh-kim-loai-3d-lap-rap-piececool-tuan-duong-ham-hms-hood-p209-sr-sp005-0.jpg",
                            Price = 450000,
                            DiscountRate = 18,
                            Slug = "mo-hinh-kim-loai-3d-lap-rap-piececool-tuan-duong-ham-hms-hood-p209-sr-sp005",
                            Stock = 15,
                            Description = "<p><strong>Mô Hình Giấy 3D Lắp Ráp CubicFun Con Cú Tuyết DS1079h (62 mảnh, Snowy Owl) - SP004</strong></p><ul><li>Mã sản phẩm:&nbsp;<strong>SP004</strong></li><li>Chất liệu: Xốp EPS và giấy</li><li>Kích thước:&nbsp;17&nbsp;x 17.3 x 24.6 CM&nbsp;</li><li>Độ khó: 3/10</li><li>Mảnh ghép: 62</li><li>Hãng sản xuất: CubicFun</li><li>Phù hợp độ tuổi: 8+</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-giay-3d\">Mô hình giấy 3D</a> với cách lắp ráp đơn giản: tách ra và ghép vào, không cần cắt và keo dán. Quan trọng hơn, người chơi có thể tháo rời mô hình, trả các chi tiết về lại miếng 2D và cất đi cho lần chơi sau</p><p><strong>ĐẶC ĐIỂM NỔI BẬC</strong></p><p>⭐ Màu sắc đẹp mắt: Màu sắc trang trí đẹp và trang nhã cho bé sự thích thú khi chơi.&nbsp;</p><p>⭐ Mô hình vững chãi: Tổng quan mô hình sau khi ráp rất cứng cáp và đẹp mắt. Mô hình có thể dựng ở không gian phòng trong thời gian dài mà không hề bị biến dạng.&nbsp;</p><p>⭐ Rèn luyện sự khéo léo, tỉ mỉ: Trong suốt quá trình mày mò lắp ráp, bé sẽ tập tính kiên trì, nhẫn nại, hiểu được giá trị lao động từ những thứ mà bé làm ra.&nbsp;</p><p>⭐ Kích thích tư duy sáng tạo: Bộ xếp hình 3D giúp bé luyện trí nhớ, tăng khả năng tư duy và phát triển trí não toàn diện. Hơn nữa, đồ chơi xếp hình còn có nhiều sản phẩm cùng chủng loại cho bé thỏa mãn niềm đam mê sưu tập.&nbsp;</p><p>⭐ Gắn kết gia đình: Hãy thử tưởng tượng xem vào một buổi tối hay cuối tuần nào đó, cả nhà cùng xếp hình, cùng cười đùa, chuyện trò rôm rả… không khí gia đình thật đầm ấm, vui vẻ biết bao.</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh giấy&nbsp;ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ.&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p><strong>THÔNG TIN THƯƠNG HIỆU&nbsp;</strong></p><p>Là một doanh nghiệp đồ chơi hàng đầu chuyên nghiên cứu, phát triển, thiết kế, sản xuất và tiếp thị về đồ chơi lắp ghép Puzzle 3D mang thương hiệu CubicFun. Với số lượng bán hàng lớn nhất trong ngành công nghiệp Puzzle 3D, các sản phẩm CubicFun được bán cho hơn 80 quốc gia trên toàn thế giới bao gồm Châu Âu, Mỹ, Nga, và Đông Nam Á và các đối tác có uy tín cao như Toys R Us, Walmart, Carrefour, Auchan , Tesco, và Barnes &amp; Noble. Ở Việt Nam, với tiêu chí đem lại giá trị về văn hóa, giáo dục, giải trí và trưng bày cho mọi nhà, cũng như thông qua đồ chơi mô hình, con người sẽ sáng tạo hơn và hạnh phúc hơn, CubicFun ngày càng được người tiêu dùng trong nước ưa chuộng.</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d #mohinhnhua3d #mohinhnonlego #lego #mohinh3dnhua #mohinhgiay3d #cubicfun&nbsp;</p>",
                            CategoryId = 1,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP006",
                            Name = "Mô Hình Kim Loại 3D Lắp Ráp Piececool Súng Trường M16A1 (86 mảnh, M16A1 Assault Rifle) HP349-SK - SP006",
                            Thumbnail = "mo-hinh-kim-loai-3d-lap-rap-piececool-sung-truong-m16a1-86-manh-m16a1-assault-rifle-hp349-sk-sp006-0.jpg",
                            Price = 350000,
                            DiscountRate = 21,
                            Slug = "mo-hinh-kim-loai-3d-lap-rap-piececool-sung-truong-m16a1-86-manh-m16a1-assault-rifle-hp349-sk-sp006",
                            Stock = 50,
                            Description = "<p>Mô Hình Kim Loại 3D Lắp Ráp Piececool Súng Trường M16A1 (86 mảnh, M16A1 Assault Rifle) HP349-SK - SP006</p><ul><li>Mã sản phẩm:&nbsp;SP006</li><li>Chất liệu: Thép không rỉ inox 430, đồng thau</li><li>Kích thước (Dài*Rộng*Cao): 30.3 x 4 x 11 cm</li><li>Độ khó: 3/10</li><li>Mảnh ghép: 86</li><li>Hãng sản xuất: Piececool</li><li>Phù hợp độ tuổi: 14+</li><li>Dụng cụ cần thiết: Kìm cắt, kìm nhọn, nhíp, bộ uốn</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-kim-loai-3d\">MÔ HÌNH KIM LOẠI 3D</a>&nbsp;được cộng đồng quốc tế đánh giá là trò chơi mang tính sáng tạo bậc nhất trong những năm gần đây. Thiết kế mang tính sáng tạo, độc đáo và độ chi tiết đáng kinh ngạc là những nét nổi bật tạo nên sức hút mạnh mẽ, khơi dậy niềm đam mê mô hình trong mỗi người chơi khi chọn mua sản phẩm. Hãy để trẻ có thêm sự lựa chọn vui chơi, tự ráp những bộ mô hình thép 3D độc đáo thay vì dành hàng giờ cho chiếc máy tính, điện thoại.</p><p><strong>SỰ VƯỢT TRỘI CỦA MÔ HÌNH KIM LOẠI 3D&nbsp;</strong></p><p>⭐ Thiết kế sáng tạo, độc đáo từ chú chuồn chuồn dễ thương, gần gũi đến chiếc tàu chiến từng làm bá chủ cả vùng biển rộng. ⭐ Độ chi tiết đáng kinh ngạc: được khắc bằng laze hiện đại cùng độ chi tiết cao từ các nhà thiết kế tài năng, mô hình có độ chạm khắc tốt, chi tiết rất rõ ràng. Đồng thời có tính dẻo và bền hơn chất liệu giấy hay gỗ.&nbsp;</p><p>⭐ Màu sắc trung thực: nguyên thuỷ màu bạc và có thể nhiều màu&nbsp;</p><p>⭐ Nhỏ gọn, dễ bảo quản: đại đa số các mẫu đều có kích thước vừa phải, đồng thời sử dụng chất liệu thép không gỉ nên mô hình hoàn toàn bền bỉ với thời gian và không yêu cầu gì quá khắt khe khi bảo quản.&nbsp;</p><p>⭐ Tính giải trí cao: cảm giác lắp ráp vài tiếng liên tục để được thành phẩm sẽ làm bạn rất thích thú</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên sử dụng các dụng cụ hỗ trợ để quá trình lắp ráp nhanh, thuận tiện và chính xác hơn&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh thép 3D&nbsp;</p><p>⭐ Bạn sử dụng kềm cắt linh kiện hoặc kềm cắt da tay phụ nữ để tách mảnh thép ra&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Ký hiệu hình tròn: bạn gập khớp nối 90 độ&nbsp;</p><p>⭐ Ký hiệu hình tam giác: bạn xoắn khớp nối 90 độ&nbsp;</p><p>⭐ Ngoài ra còn có các bộ phần cần uốn tròn. Bạn nên sử dụng bộ dụng cụ uốn kim loại 3D hoặc dụng cụ tại nhà&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d</p>",
                            CategoryId = 2,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP007",
                            Name = "Mô Hình Gỗ 3D Lắp Ráp ROBOTIME ROKR Súng Trường AK-47 LQ901 – SP007",
                            Thumbnail = "mo-hinh-go-3d-lap-rap-robotime-rokr-sung-truong-ak-47-lq901-sp007-0.jpg",
                            Price = 740000,
                            DiscountRate = 26,
                            Slug = "mo-hinh-go-3d-lap-rap-robotime-rokr-sung-truong-ak-47-lq901-sp007",
                            Stock = 65,
                            Description = "<p><strong>Mô Hình Gỗ 3D Lắp Ráp ROBOTIME ROKR Súng Trường AK-47 LQ901 – SP007</strong></p><ul><li>Mã sản phẩm:&nbsp;SP007</li><li>Chất liệu: Gỗ ép, vải, nhựa</li><li>Kích thước (Dài*Rộng*Cao):&nbsp;28 X 2.1 X 8.6 CM</li><li>Độ khó: 4/10</li><li>Mảnh ghép: 315</li><li>Hãng sản xuất: Robotime</li><li>Phù hợp độ tuổi: 14+</li><li>Dụng cụ cần thiết: Kìm cắt, kìm nhọn, nhíp, bộ uốn</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-go-3d\">MÔ HÌNH GỖ 3D</a> ROBOTIME&nbsp;được cộng đồng quốc tế đánh giá là trò chơi mang tính sáng tạo bậc nhất trong những năm gần đây. Thiết kế mang tính sáng tạo, độc đáo và độ chi tiết đáng kinh ngạc là những nét nổi bật tạo nên sức hút mạnh mẽ, khơi dậy niềm đam mê mô hình trong mỗi người chơi khi chọn mua sản phẩm. Hãy để trẻ có thêm sự lựa chọn vui chơi, tự ráp những bộ mô hình 3D gỗ&nbsp;độc đáo thay vì dành hàng giờ cho chiếc máy tính, điện thoại.</p><p><strong>CAM KẾT ĐỐI VỚI KHÁCH HÀNG</strong></p><p>⭐ Hàng chính hãng Robotime, hướng dẫn lắp ghép bằng tiếng Anh</p><p>⭐ Bảo hành sản phẩm nếu thiếu mảnh hoặc bộ phận</p><p>⭐ Hỗ trợ hướng dẫn lắp ráp nếu khách hàng gặp khó khăn</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh gỗ ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ. Riêng nhà Dollhouse cần có thêm nhíp&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d</p>",
                            CategoryId = 2,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP008",
                            Name = "Mô Hình Gỗ 3D Lắp Ráp ROBOTIME Súng Cao Bồi Terminator M870 LQ501 - SP008",
                            Thumbnail = "mo-hinh-go-3d-lap-rap-robotime-sung-cao-boi-terminator-m870-lq501-sp008-0.jpg",
                            Price = 595000,
                            DiscountRate = 0,
                            Slug = "mo-hinh-go-3d-lap-rap-robotime-sung-cao-boi-terminator-m870-lq501-sp008",
                            Stock = 23,
                            Description = "<p><strong>Mô Hình Gỗ 3D Lắp Ráp ROBOTIME Súng Cao Bồi Terminator M870 LQ501 - SP008</strong></p><ul><li>Mã sản phẩm:SP008</li><li>Chất liệu: Gỗ ép, vải, nhựa</li><li>Kích thước (Dài*Rộng*Cao):43.3 X 6 X 9.2 CM</li><li>Độ khó: 4/10</li><li>Mảnh ghép: 172</li><li>Hãng sản xuất: Robotime</li><li>Phù hợp độ tuổi: 14+</li><li>Dụng cụ cần thiết: Kìm cắt, kìm nhọn, nhíp, bộ uốn</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-go-3d\">MÔ HÌNH GỖ 3D</a> ROBOTIME&nbsp;được cộng đồng quốc tế đánh giá là trò chơi mang tính sáng tạo bậc nhất trong những năm gần đây. Thiết kế mang tính sáng tạo, độc đáo và độ chi tiết đáng kinh ngạc là những nét nổi bật tạo nên sức hút mạnh mẽ, khơi dậy niềm đam mê mô hình trong mỗi người chơi khi chọn mua sản phẩm. Hãy để trẻ có thêm sự lựa chọn vui chơi, tự ráp những bộ mô hình 3D gỗ&nbsp;độc đáo thay vì dành hàng giờ cho chiếc máy tính, điện thoại.</p><p><strong>CAM KẾT ĐỐI VỚI KHÁCH HÀNG</strong></p><p>⭐ Hàng chính hãng Robotime, hướng dẫn lắp ghép bằng tiếng Anh</p><p>⭐ Bảo hành sản phẩm nếu thiếu mảnh hoặc bộ phận</p><p>⭐ Hỗ trợ hướng dẫn lắp ráp nếu khách hàng gặp khó khăn</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh gỗ ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ. Riêng nhà Dollhouse cần có thêm nhíp&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d</p>",
                            CategoryId = 2,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP009",
                            Name = "Mô Hình Nhựa 3D Lắp Ráp Harry Potter Hogwarts Icons Collectors Edition 6050 (3010 mảnh) - SP009",
                            Thumbnail = "mo-hinh-nhua-3d-lap-rap-harry-potter-hogwarts-icons-collectors-edition-6050-3010-manh-sp009-0.jpg",
                            Price = 1650000,
                            DiscountRate = 18,
                            Slug = "mo-hinh-nhua-3d-lap-rap-harry-potter-hogwarts-icons-collectors-edition-6050-3010-manh-sp009",
                            Stock = 3,
                            Description = "<p><strong>Mô Hình Nhựa 3D Lắp Ráp Harry Potter Hogwarts Icons Collectors Edition 6050 (3010 mảnh) - SP009</strong></p><ul><li>Mã sản phẩm:&nbsp;SP009</li><li>Chất liệu: Nhựa ABS</li><li>Kích thước (Dài*Rộng*Cao): 50 X 33 X 44 CM</li><li>Độ khó: 6/10</li><li>Mảnh ghép: 3010</li><li>Hãng sản xuất: OEM</li><li>Phù hợp độ tuổi: 8+</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-nhua-3d\">MÔ HÌNH NHỰA&nbsp;3D</a>&nbsp;được cộng đồng quốc tế đánh giá là trò chơi hấp dẫn và an toàn nhất hiện nay. Ra đời từ những năm 1960s với hàng nghìn mô hình lắp ráp dạng tĩnh. Nay mô hình nhựa 3D non Lego đã có các phiên bản điều khiển, chuyển động được bằng motor và pin sạc. Hãy khám phá ngay các bạn nhé!</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh nhựa&nbsp;ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ.&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d #mohinhnhua3d #mohinhnonlego #lego #mohinh3dnhua</p>",
                            CategoryId = 3,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP010",
                            Name = "Mô Hình Nhựa 3D Lắp Ráp Harry Potter Phượng Hoàng Lửa Fawkes 86394 (597 mảnh) - SP010",
                            Thumbnail = "mo-hinh-nhua-3d-lap-rap-harry-potter-phuong-hoang-lua-fawkes-86394-597-manh-sp010-0.jpg",
                            Price = 375000,
                            DiscountRate = 26,
                            Slug = "mo-hinh-nhua-3d-lap-rap-harry-potter-phuong-hoang-lua-fawkes-86394-597-manh-sp010",
                            Stock = 10,
                            Description = "<p><strong>Mô Hình Nhựa 3D Lắp Ráp Harry Potter Phượng Hoàng Lửa Fawkes 86394 (597 mảnh) - SP010</strong></p><ul><li>Mã sản phẩm:&nbsp;SP010</li><li>Chất liệu: Nhựa ABS</li><li>Kích thước (Dài*Rộng*Cao): 35 X 24 X 18 CM</li><li>Độ khó: 2/10</li><li>Mảnh ghép: 597</li><li>Hãng sản xuất: OEM</li><li>Phù hợp độ tuổi: 8+</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-nhua-3d\">MÔ HÌNH NHỰA&nbsp;3D</a>&nbsp;được cộng đồng quốc tế đánh giá là trò chơi hấp dẫn và an toàn nhất hiện nay. Ra đời từ những năm 1960s với hàng nghìn mô hình lắp ráp dạng tĩnh. Nay mô hình nhựa 3D non Lego đã có các phiên bản điều khiển, chuyển động được bằng motor và pin sạc. Hãy khám phá ngay các bạn nhé!</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh nhựa&nbsp;ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ.&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d #mohinhnhua3d #mohinhnonlego #lego #mohinh3dnhua</p>",
                            CategoryId = 3,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP011",
                            Name = "Mô Hình Kim Loại 3D Lắp Ráp Metal Head Harry Potter The Burrow - SP011",
                            Thumbnail = "mo-hinh-kim-loai-3d-lap-rap-metal-head-harry-potter-the-burrow-sp011-0.jpg",
                            Price = 155000,
                            DiscountRate = 11,
                            Slug = "mo-hinh-kim-loai-3d-lap-rap-metal-head-harry-potter-the-burrow-sp011",
                            Stock = 2,
                            Description = "<p><strong>Mô Hình Kim Loại 3D Lắp Ráp Metal Head Harry Potter The Burrow – SP011</strong></p><ul><li>Mã sản phẩm:&nbsp;SP011</li><li>Chất liệu: Thép không rỉ inox 430, đồng thau</li><li>Kích thước (Dài*Rộng*Cao):&nbsp;7.37 X 4.8 X 10 CM</li><li>Độ khó: 5/10</li><li>Mảnh ghép: 47</li><li>Hãng sản xuất: Metal Head</li><li>Phù hợp độ tuổi: 14+</li><li>Dụng cụ cần thiết: Kìm cắt, kìm nhọn, nhíp, bộ uốn</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-kim-loai-3d\">MÔ HÌNH KIM LOẠI 3D</a> được cộng đồng quốc tế đánh giá là trò chơi mang tính sáng tạo bậc nhất trong những năm gần đây. Thiết kế mang tính sáng tạo, độc đáo và độ chi tiết đáng kinh ngạc là những nét nổi bật tạo nên sức hút mạnh mẽ, khơi dậy niềm đam mê mô hình trong mỗi người chơi khi chọn mua sản phẩm. Hãy để trẻ có thêm sự lựa chọn vui chơi, tự ráp những bộ mô hình thép 3D độc đáo thay vì dành hàng giờ cho chiếc máy tính, điện thoại.</p><p><strong>SỰ VƯỢT TRỘI CỦA MÔ HÌNH KIM LOẠI 3D&nbsp;</strong></p><p>⭐ Thiết kế sáng tạo, độc đáo từ chú chuồn chuồn dễ thương, gần gũi đến chiếc tàu chiến từng làm bá chủ cả vùng biển rộng. ⭐ Độ chi tiết đáng kinh ngạc: được khắc bằng laze hiện đại cùng độ chi tiết cao từ các nhà thiết kế tài năng, mô hình có độ chạm khắc tốt, chi tiết rất rõ ràng. Đồng thời có tính dẻo và bền hơn chất liệu giấy hay gỗ.&nbsp;</p><p>⭐ Màu sắc trung thực: nguyên thuỷ màu bạc và có thể nhiều màu&nbsp;</p><p>⭐ Nhỏ gọn, dễ bảo quản: đại đa số các mẫu đều có kích thước vừa phải, đồng thời sử dụng chất liệu thép không gỉ nên mô hình hoàn toàn bền bỉ với thời gian và không yêu cầu gì quá khắt khe khi bảo quản.&nbsp;</p><p>⭐ Tính giải trí cao: cảm giác lắp ráp vài tiếng liên tục để được thành phẩm sẽ làm bạn rất thích thú</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên sử dụng các dụng cụ hỗ trợ để quá trình lắp ráp nhanh, thuận tiện và chính xác hơn&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh thép 3D&nbsp;</p><p>⭐ Bạn sử dụng kềm cắt linh kiện hoặc kềm cắt da tay phụ nữ để tách mảnh thép ra&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Ký hiệu hình tròn: bạn gập khớp nối 90 độ&nbsp;</p><p>⭐ Ký hiệu hình tam giác: bạn xoắn khớp nối 90 độ&nbsp;</p><p>⭐ Ngoài ra còn có các bộ phần cần uốn tròn. Bạn nên sử dụng bộ dụng cụ uốn kim loại 3D hoặc dụng cụ tại nhà&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d</p>",
                            CategoryId = 3,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP012",
                            Name = "Mô Hình Gỗ 3D Lắp Ráp ROBOTIME DIY Dollhouse Nhà Tí Hon Joy’s Peninsula Living Room DG141 – SP012",
                            Thumbnail = "mo-hinh-go-3d-lap-rap-robotime-diy-dollhouse-nha-ti-honjoy-s-peninsula-living-room-dg141-sp012-0.jpg",
                            Price = 850000,
                            DiscountRate = 40,
                            Slug = "mo-hinh-go-3d-lap-rap-robotime-diy-dollhouse-nha-ti-honjoy-s-peninsula-living-room-dg141-sp012",
                            Stock = 0,
                            Description = "<p><strong>Mô Hình Gỗ 3D Lắp Ráp ROBOTIME DIY Dollhouse Nhà Tí Hon Joy’s Peninsula Living Room DG141 – SP012</strong></p><ul><li>Mã sản phẩm:&nbsp;SP012</li><li>Chất liệu: Gỗ ép, vải, nhựa</li><li>Kích thước (Dài*Rộng*Cao):&nbsp;23 X 15 X 23 CM</li><li>Độ khó: 5/10</li><li>Mảnh ghép: 250</li><li>Hãng sản xuất: Robotime</li><li>Phù hợp độ tuổi: 14+</li><li>Dụng cụ cần thiết: Kìm cắt, kìm nhọn, nhíp, bộ uốn</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-go-3d\">MÔ HÌNH GỖ 3D</a> ROBOTIME&nbsp;được cộng đồng quốc tế đánh giá là trò chơi mang tính sáng tạo bậc nhất trong những năm gần đây. Thiết kế mang tính sáng tạo, độc đáo và độ chi tiết đáng kinh ngạc là những nét nổi bật tạo nên sức hút mạnh mẽ, khơi dậy niềm đam mê mô hình trong mỗi người chơi khi chọn mua sản phẩm. Hãy để trẻ có thêm sự lựa chọn vui chơi, tự ráp những bộ mô hình 3D gỗ&nbsp;độc đáo thay vì dành hàng giờ cho chiếc máy tính, điện thoại.</p><p><strong>CAM KẾT ĐỐI VỚI KHÁCH HÀNG</strong></p><p>⭐ Hàng chính hãng Robotime, hướng dẫn lắp ghép bằng tiếng Anh</p><p>⭐ Bảo hành sản phẩm nếu thiếu mảnh hoặc bộ phận</p><p>⭐ Hỗ trợ hướng dẫn lắp ráp nếu khách hàng gặp khó khăn</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh gỗ ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ. Riêng nhà Dollhouse cần có thêm nhíp&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d</p>",
                            CategoryId = 4,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP013",
                            Name = "Mô Hình Gỗ 3D Lắp Ráp ROBOTIME Rolife Bubble Bath (Bathroom) DS018 - SP013",
                            Thumbnail = "mo-hinh-go-3d-lap-rap-robotime-rolife-bubble-bath-bathroom-ds018-sp013-0.jpg",
                            Price = 285000,
                            DiscountRate = 32,
                            Slug = "mo-hinh-go-3d-lap-rap-robotime-rolife-bubble-bath-bathroom-ds018-sp013",
                            Stock = 70,
                            Description = "<p><strong>Mô Hình Gỗ 3D Lắp Ráp ROBOTIME Rolife Bubble Bath (Bathroom) DS018 - SP013</strong></p><ul><li>Mã sản phẩm:&nbsp;SP013</li><li>Chất liệu: Gỗ ép, vải, nhựa</li><li>Kích thước (Dài*Rộng*Cao):7 X 7 X 9 CM</li><li>Độ khó: 2/10</li><li>Mảnh ghép: 150</li><li>Hãng sản xuất: Robotime</li><li>Phù hợp độ tuổi: 14+</li><li>Dụng cụ cần thiết: Kìm cắt, kìm nhọn, nhíp, bộ uốn</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-go-3d\">MÔ HÌNH GỖ 3D</a> ROBOTIME&nbsp;được cộng đồng quốc tế đánh giá là trò chơi mang tính sáng tạo bậc nhất trong những năm gần đây. Thiết kế mang tính sáng tạo, độc đáo và độ chi tiết đáng kinh ngạc là những nét nổi bật tạo nên sức hút mạnh mẽ, khơi dậy niềm đam mê mô hình trong mỗi người chơi khi chọn mua sản phẩm. Hãy để trẻ có thêm sự lựa chọn vui chơi, tự ráp những bộ mô hình 3D gỗ&nbsp;độc đáo thay vì dành hàng giờ cho chiếc máy tính, điện thoại.</p><p><strong>CAM KẾT ĐỐI VỚI KHÁCH HÀNG</strong></p><p>⭐ Hàng chính hãng Robotime, hướng dẫn lắp ghép bằng tiếng Anh</p><p>⭐ Bảo hành sản phẩm nếu thiếu mảnh hoặc bộ phận</p><p>⭐ Hỗ trợ hướng dẫn lắp ráp nếu khách hàng gặp khó khăn</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh gỗ ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ. Riêng nhà Dollhouse cần có thêm nhíp&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d</p>",
                            CategoryId = 4,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP014",
                            Name = "Mô Hình Kim Loại Lắp Ráp 3D Metal Mosaic Máy Bay de Havilland Tiger Moth - SP014",
                            Thumbnail = "Mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-de-havilland-tiger-moth-sp014-0.jpg",
                            Price = 48000,
                            DiscountRate = 0,
                            Slug = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-de-havilland-tiger-moth-sp014",
                            Stock = 22,
                            Description = "<p><strong>Mô Hình Kim Loại Lắp Ráp 3D Metal Mosaic Máy Bay de Havilland Tiger Moth – SP014</strong></p><ul><li>Mã sản phẩm:&nbsp;SP014</li><li>Chất liệu: Thép không rỉ inox 430, đồng thau</li><li>Kích thước (Dài*Rộng*Cao):9.5 X 7.3 X 2.5CM</li><li>Độ khó: 1/10</li><li>Mảnh ghép: 15</li><li>Hãng sản xuất:&nbsp;Metal Mosaic</li><li>Phù hợp độ tuổi: 14+</li><li>Dụng cụ cần thiết: Kìm cắt, kìm nhọn, nhíp, bộ uốn</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-kim-loai-3d\">MÔ HÌNH KIM LOẠI 3D</a> được cộng đồng quốc tế đánh giá là trò chơi mang tính sáng tạo bậc nhất trong những năm gần đây. Thiết kế mang tính sáng tạo, độc đáo và độ chi tiết đáng kinh ngạc là những nét nổi bật tạo nên sức hút mạnh mẽ, khơi dậy niềm đam mê mô hình trong mỗi người chơi khi chọn mua sản phẩm. Hãy để trẻ có thêm sự lựa chọn vui chơi, tự ráp những bộ mô hình thép 3D độc đáo thay vì dành hàng giờ cho chiếc máy tính, điện thoại.</p><p><strong>SỰ VƯỢT TRỘI CỦA MÔ HÌNH KIM LOẠI 3D&nbsp;</strong></p><p>⭐ Thiết kế sáng tạo, độc đáo từ chú chuồn chuồn dễ thương, gần gũi đến chiếc tàu chiến từng làm bá chủ cả vùng biển rộng. ⭐ Độ chi tiết đáng kinh ngạc: được khắc bằng laze hiện đại cùng độ chi tiết cao từ các nhà thiết kế tài năng, mô hình có độ chạm khắc tốt, chi tiết rất rõ ràng. Đồng thời có tính dẻo và bền hơn chất liệu giấy hay gỗ.&nbsp;</p><p>⭐ Màu sắc trung thực: nguyên thuỷ màu bạc và có thể nhiều màu&nbsp;</p><p>⭐ Nhỏ gọn, dễ bảo quản: đại đa số các mẫu đều có kích thước vừa phải, đồng thời sử dụng chất liệu thép không gỉ nên mô hình hoàn toàn bền bỉ với thời gian và không yêu cầu gì quá khắt khe khi bảo quản.&nbsp;</p><p>⭐ Tính giải trí cao: cảm giác lắp ráp vài tiếng liên tục để được thành phẩm sẽ làm bạn rất thích thú</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên sử dụng các dụng cụ hỗ trợ để quá trình lắp ráp nhanh, thuận tiện và chính xác hơn&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh thép 3D&nbsp;</p><p>⭐ Bạn sử dụng kềm cắt linh kiện hoặc kềm cắt da tay phụ nữ để tách mảnh thép ra&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Ký hiệu hình tròn: bạn gập khớp nối 90 độ&nbsp;</p><p>⭐ Ký hiệu hình tam giác: bạn xoắn khớp nối 90 độ&nbsp;</p><p>⭐ Ngoài ra còn có các bộ phần cần uốn tròn. Bạn nên sử dụng bộ dụng cụ uốn kim loại 3D hoặc dụng cụ tại nhà&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d</p>",
                            CategoryId = 5,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP015",
                            Name = "Mô Hình Nhựa 3D Lắp Ráp 18K Super Game of Thrones Con Rồng Băng Viserion 9902 (1889 mảnh) - SP015",
                            Thumbnail = "mo-hinh-nhua-3d-lap-rap-game-of-thrones-con-rong-bang-viserion-9902-1889-manh-sp015-0.jpg",
                            Price = 1350000,
                            DiscountRate = 29,
                            Slug = "mo-hinh-nhua-3d-lap-rap-game-of-thrones-con-rong-bang-viserion-9902-1889-manh-sp015",
                            Stock = 8,
                            Description = "<p><strong>Mô Hình Nhựa 3D Lắp Ráp 18K Super Game of Thrones Con Rồng Băng Viserion 9902 (1889 mảnh) - SP015</strong></p><ul><li>Mã sản phẩm:&nbsp;SP015</li><li>Chất liệu: Nhựa ABS</li><li>Kích thước (Dài*Rộng*Cao): 102 X 90 X 24 CM</li><li>Độ khó:&nbsp; 6/10</li><li>Mảnh ghép: 1889</li><li>Hãng sản xuất:&nbsp;18K Super</li><li>Phù hợp độ tuổi: 8+</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-nhua-3d\">MÔ HÌNH NHỰA&nbsp;3D</a>&nbsp;được cộng đồng quốc tế đánh giá là trò chơi hấp dẫn và an toàn nhất hiện nay. Ra đời từ những năm 1960s với hàng nghìn mô hình lắp ráp dạng tĩnh. Nay mô hình nhựa 3D non Lego đã có các phiên bản điều khiển, chuyển động được bằng motor và pin sạc. Hãy khám phá ngay các bạn nhé!</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh nhựa&nbsp;ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ.&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d #mohinhnhua3d #mohinhnonlego #lego #mohinh3dnhua</p>",
                            CategoryId = 6,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP016",
                            Name = "Mô Hình Kim Loại Lắp Ráp 3D Metal Mosaic Máy Bay Saint Louis - SP016",
                            Thumbnail = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-saint-louis-sp016-0.jpg",
                            Price = 48000,
                            DiscountRate = 0,
                            Slug = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-saint-louis-sp016",
                            Stock = 48,
                            Description = "<p><strong>Mô Hình Kim Loại Lắp Ráp 3D Metal Mosaic Máy Bay Saint Louis – SP016</strong></p><ul><li>Mã sản phẩm:&nbsp;SP016</li><li>Chất liệu: Thép không rỉ inox 430, đồng thau</li><li>Kích thước (Dài*Rộng*Cao): 12.2 X 9 X 2.4CM</li><li>Độ khó: 1/10</li><li>Mảnh ghép: 16</li><li>Hãng sản xuất:&nbsp;Metal Mosaic</li><li>Phù hợp độ tuổi: 14+</li><li>Dụng cụ cần thiết: Kìm cắt, kìm nhọn, nhíp, bộ uốn</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-kim-loai-3d\">MÔ HÌNH KIM LOẠI 3D</a> được cộng đồng quốc tế đánh giá là trò chơi mang tính sáng tạo bậc nhất trong những năm gần đây. Thiết kế mang tính sáng tạo, độc đáo và độ chi tiết đáng kinh ngạc là những nét nổi bật tạo nên sức hút mạnh mẽ, khơi dậy niềm đam mê mô hình trong mỗi người chơi khi chọn mua sản phẩm. Hãy để trẻ có thêm sự lựa chọn vui chơi, tự ráp những bộ mô hình thép 3D độc đáo thay vì dành hàng giờ cho chiếc máy tính, điện thoại.</p><p><strong>SỰ VƯỢT TRỘI CỦA MÔ HÌNH KIM LOẠI 3D&nbsp;</strong></p><p>⭐ Thiết kế sáng tạo, độc đáo từ chú chuồn chuồn dễ thương, gần gũi đến chiếc tàu chiến từng làm bá chủ cả vùng biển rộng. ⭐ Độ chi tiết đáng kinh ngạc: được khắc bằng laze hiện đại cùng độ chi tiết cao từ các nhà thiết kế tài năng, mô hình có độ chạm khắc tốt, chi tiết rất rõ ràng. Đồng thời có tính dẻo và bền hơn chất liệu giấy hay gỗ.&nbsp;</p><p>⭐ Màu sắc trung thực: nguyên thuỷ màu bạc và có thể nhiều màu&nbsp;</p><p>⭐ Nhỏ gọn, dễ bảo quản: đại đa số các mẫu đều có kích thước vừa phải, đồng thời sử dụng chất liệu thép không gỉ nên mô hình hoàn toàn bền bỉ với thời gian và không yêu cầu gì quá khắt khe khi bảo quản.&nbsp;</p><p>⭐ Tính giải trí cao: cảm giác lắp ráp vài tiếng liên tục để được thành phẩm sẽ làm bạn rất thích thú</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên sử dụng các dụng cụ hỗ trợ để quá trình lắp ráp nhanh, thuận tiện và chính xác hơn&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh thép 3D&nbsp;</p><p>⭐ Bạn sử dụng kềm cắt linh kiện hoặc kềm cắt da tay phụ nữ để tách mảnh thép ra&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Ký hiệu hình tròn: bạn gập khớp nối 90 độ&nbsp;</p><p>⭐ Ký hiệu hình tam giác: bạn xoắn khớp nối 90 độ&nbsp;</p><p>⭐ Ngoài ra còn có các bộ phần cần uốn tròn. Bạn nên sử dụng bộ dụng cụ uốn kim loại 3D hoặc dụng cụ tại nhà&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d</p>",
                            CategoryId = 5,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP017",
                            Name = "Mô Hình Giấy 3D Lắp Ráp CubicFun Triceratops DS1052h (44 mảnh) - SP017",
                            Thumbnail = "mo-hinh-giay-3d-lap-rap-cubicfun-triceratops-ds1052h-44-manh-sp017-0.jpg",
                            Price = 245000,
                            DiscountRate = 1,
                            Slug = "mo-hinh-giay-3d-lap-rap-cubicfun-triceratops-ds1052h-44-manh-sp017",
                            Stock = 29,
                            Description = "<p><strong>Mô Hình Giấy 3D Lắp Ráp CubicFun Triceratops DS1052h (44 mảnh) - SP017</strong></p><ul><li>Mã sản phẩm:&nbsp;SP017</li><li>Chất liệu: Xốp EPS và giấy</li><li>Kích thước:&nbsp;39×16.5×18cm</li><li>Độ khó: 2/10</li><li>Mảnh ghép: 44</li><li>Hãng sản xuất: CubicFun</li><li>Phù hợp độ tuổi: 8+</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-giay-3d\">Mô hình giấy 3D</a> với cách lắp ráp đơn giản: tách ra và ghép vào, không cần cắt và keo dán. Quan trọng hơn, người chơi có thể tháo rời mô hình, trả các chi tiết về lại miếng 2D và cất đi cho lần chơi sau</p><p><strong>ĐẶC ĐIỂM NỔI BẬC</strong></p><p>⭐ Màu sắc đẹp mắt: Màu sắc trang trí đẹp và trang nhã cho bé sự thích thú khi chơi.&nbsp;</p><p>⭐ Mô hình vững chãi: Tổng quan mô hình sau khi ráp rất cứng cáp và đẹp mắt. Mô hình có thể dựng ở không gian phòng trong thời gian dài mà không hề bị biến dạng.&nbsp;</p><p>⭐ Rèn luyện sự khéo léo, tỉ mỉ: Trong suốt quá trình mày mò lắp ráp, bé sẽ tập tính kiên trì, nhẫn nại, hiểu được giá trị lao động từ những thứ mà bé làm ra.&nbsp;</p><p>⭐ Kích thích tư duy sáng tạo: Bộ xếp hình 3D giúp bé luyện trí nhớ, tăng khả năng tư duy và phát triển trí não toàn diện. Hơn nữa, đồ chơi xếp hình còn có nhiều sản phẩm cùng chủng loại cho bé thỏa mãn niềm đam mê sưu tập.&nbsp;</p><p>⭐ Gắn kết gia đình: Hãy thử tưởng tượng xem vào một buổi tối hay cuối tuần nào đó, cả nhà cùng xếp hình, cùng cười đùa, chuyện trò rôm rả… không khí gia đình thật đầm ấm, vui vẻ biết bao.</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh giấy&nbsp;ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ.&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p><strong>THÔNG TIN THƯƠNG HIỆU&nbsp;</strong></p><p>Là một doanh nghiệp đồ chơi hàng đầu chuyên nghiên cứu, phát triển, thiết kế, sản xuất và tiếp thị về đồ chơi lắp ghép Puzzle 3D mang thương hiệu CubicFun. Với số lượng bán hàng lớn nhất trong ngành công nghiệp Puzzle 3D, các sản phẩm CubicFun được bán cho hơn 80 quốc gia trên toàn thế giới bao gồm Châu Âu, Mỹ, Nga, và Đông Nam Á và các đối tác có uy tín cao như Toys R Us, Walmart, Carrefour, Auchan , Tesco, và Barnes &amp; Noble. Ở Việt Nam, với tiêu chí đem lại giá trị về văn hóa, giáo dục, giải trí và trưng bày cho mọi nhà, cũng như thông qua đồ chơi mô hình, con người sẽ sáng tạo hơn và hạnh phúc hơn, CubicFun ngày càng được người tiêu dùng trong nước ưa chuộng.</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d #mohinhnhua3d #mohinhnonlego #lego #mohinh3dnhua #mohinhgiay3d #cubicfun&nbsp;</p>",
                            CategoryId = 6,
                            Status = 1
                        },
                        new Product
                        {
                            ProductCode = "SP018",
                            Name = "Mô Hình Giấy 3D Lắp Ráp CubicFun Tyrannosaurus REX DS1051h (52 mảnh) - SP018",
                            Thumbnail = "mo-hinh-giay-3d-lap-rap-cubicfun-tyrannosaurus-rex-ds1051h-52-manh-sp018-0.jpg",
                            Price = 245000,
                            DiscountRate = 1,
                            Slug = "mo-hinh-giay-3d-lap-rap-cubicfun-tyrannosaurus-rex-ds1051h-52-manh-sp018",
                            Stock = 12,
                            Description = "<p><strong>Mô Hình Giấy 3D Lắp Ráp CubicFun Tyrannosaurus REX DS1051h (52 mảnh) - SP018</strong></p><ul><li>Mã sản phẩm:&nbsp;SP018</li><li>Chất liệu: Xốp EPS và giấy</li><li>Kích thước:&nbsp;44×17×20cm</li><li>Độ khó: 2/10</li><li>Mảnh ghép: 52</li><li>Hãng sản xuất: CubicFun</li><li>Phù hợp độ tuổi: 8+</li><li>Hướng dẫn lắp ráp mô hình chi tiết, dễ hiểu</li></ul><p><a href=\"https://artpuzzle.vn/collections/mo-hinh-giay-3d\">Mô hình giấy 3D</a> với cách lắp ráp đơn giản: tách ra và ghép vào, không cần cắt và keo dán. Quan trọng hơn, người chơi có thể tháo rời mô hình, trả các chi tiết về lại miếng 2D và cất đi cho lần chơi sau</p><p><strong>ĐẶC ĐIỂM NỔI BẬC</strong></p><p>⭐ Màu sắc đẹp mắt: Màu sắc trang trí đẹp và trang nhã cho bé sự thích thú khi chơi.&nbsp;</p><p>⭐ Mô hình vững chãi: Tổng quan mô hình sau khi ráp rất cứng cáp và đẹp mắt. Mô hình có thể dựng ở không gian phòng trong thời gian dài mà không hề bị biến dạng.&nbsp;</p><p>⭐ Rèn luyện sự khéo léo, tỉ mỉ: Trong suốt quá trình mày mò lắp ráp, bé sẽ tập tính kiên trì, nhẫn nại, hiểu được giá trị lao động từ những thứ mà bé làm ra.&nbsp;</p><p>⭐ Kích thích tư duy sáng tạo: Bộ xếp hình 3D giúp bé luyện trí nhớ, tăng khả năng tư duy và phát triển trí não toàn diện. Hơn nữa, đồ chơi xếp hình còn có nhiều sản phẩm cùng chủng loại cho bé thỏa mãn niềm đam mê sưu tập.&nbsp;</p><p>⭐ Gắn kết gia đình: Hãy thử tưởng tượng xem vào một buổi tối hay cuối tuần nào đó, cả nhà cùng xếp hình, cùng cười đùa, chuyện trò rôm rả… không khí gia đình thật đầm ấm, vui vẻ biết bao.</p><p><strong>HƯỚNG DẪN LẮP RÁP CHO NGƯỜI MỚI&nbsp;</strong></p><p>Để có được 1 mô hình lắp ghép 3d hoàn hảo, bạn nên tham khảo các bước bên dưới trước khi chơi&nbsp;</p><p>⭐ Mở hộp/bao bì sản phẩm, lấy các mảnh ghép và tờ hướng dẫn&nbsp;</p><p>⭐ Đọc theo hướng dẫn từng bước, tại mỗi bước sẽ có ghi chú ký hiệu từng mảnh giấy&nbsp;ghép&nbsp;3D&nbsp;</p><p>⭐ Bạn không cần sử dụng thêm dụng cụ vì đã có sẵn trong bộ.&nbsp;</p><p>⭐ Các bộ phận sẽ được kết nối với nhau bằng các khớp nối. Được ký hiệu rõ ràng tại mỗi bước&nbsp;</p><p>⭐ Cuối cùng, bạn nên đọc kỹ từng bước trước khi làm&nbsp;</p><p><strong>THÔNG TIN THƯƠNG HIỆU&nbsp;</strong></p><p>Là một doanh nghiệp đồ chơi hàng đầu chuyên nghiên cứu, phát triển, thiết kế, sản xuất và tiếp thị về đồ chơi lắp ghép Puzzle 3D mang thương hiệu CubicFun. Với số lượng bán hàng lớn nhất trong ngành công nghiệp Puzzle 3D, các sản phẩm CubicFun được bán cho hơn 80 quốc gia trên toàn thế giới bao gồm Châu Âu, Mỹ, Nga, và Đông Nam Á và các đối tác có uy tín cao như Toys R Us, Walmart, Carrefour, Auchan , Tesco, và Barnes &amp; Noble. Ở Việt Nam, với tiêu chí đem lại giá trị về văn hóa, giáo dục, giải trí và trưng bày cho mọi nhà, cũng như thông qua đồ chơi mô hình, con người sẽ sáng tạo hơn và hạnh phúc hơn, CubicFun ngày càng được người tiêu dùng trong nước ưa chuộng.</p><p>#dochoixephinh #mohinhlaprap #mohinhkientruc #mohinhkimloai #mohinhlaprap3dkimloai #mohinhlaprap3dthep #mohinh3dkimloai #mohinhthep3d #mohinhkimloai3d #mohinhnhua3d #mohinhnonlego #lego #mohinh3dnhua #mohinhgiay3d #cubicfun&nbsp;</p>",
                            CategoryId = 6,
                            Status = 1
                        }
                        );
                    context.SaveChanges();
                }
                if (!context.ProductsImages.Any())
                {
                    context.ProductsImages.AddRange(
                       new ProductsImage
                       {
                           ProductId = 1,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-con-huou-cao-co-p857h-43-manh-giraffe-sp001-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 1,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-con-huou-cao-co-p857h-43-manh-giraffe-sp001-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 1,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-con-huou-cao-co-p857h-43-manh-giraffe-sp001-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 1,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-con-huou-cao-co-p857h-43-manh-giraffe-sp001-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 1,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-con-huou-cao-co-p857h-43-manh-giraffe-sp001-4.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 2,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-the-gioi-bac-cuc-ds0983h-73-manh-national-geographic-arctic-sp002-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 2,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-the-gioi-bac-cuc-ds0983h-73-manh-national-geographic-arctic-sp002-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 2,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-the-gioi-bac-cuc-ds0983h-73-manh-national-geographic-arctic-sp002-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 2,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-the-gioi-bac-cuc-ds0983h-73-manh-national-geographic-arctic-sp002-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 2,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-the-gioi-bac-cuc-ds0983h-73-manh-national-geographic-arctic-sp002-4.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 3,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-piececool-thiet-giap-ham-uss-missouri-sp003-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 3,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-piececool-thiet-giap-ham-uss-missouri-sp003-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 3,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-piececool-thiet-giap-ham-uss-missouri-sp003-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 3,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-piececool-thiet-giap-ham-uss-missouri-sp003-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 4,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-con-cu-tuyet-ds1079h-62-manh-snowy-owl-sp004-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 4,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-con-cu-tuyet-ds1079h-62-manh-snowy-owl-sp004-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 4,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-con-cu-tuyet-ds1079h-62-manh-snowy-owl-sp004-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 4,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-con-cu-tuyet-ds1079h-62-manh-snowy-owl-sp004-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 4,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-con-cu-tuyet-ds1079h-62-manh-snowy-owl-sp004-4.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 5,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-piececool-tuan-duong-ham-hms-hood-p209-sr-sp005-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 5,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-piececool-tuan-duong-ham-hms-hood-p209-sr-sp005-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 5,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-piececool-tuan-duong-ham-hms-hood-p209-sr-sp005-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 5,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-piececool-tuan-duong-ham-hms-hood-p209-sr-sp005-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 6,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-piececool-sung-truong-m16a1-86-manh-m16a1-assault-rifle-hp349-sk-sp006-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 6,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-piececool-sung-truong-m16a1-86-manh-m16a1-assault-rifle-hp349-sk-sp006-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 6,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-piececool-sung-truong-m16a1-86-manh-m16a1-assault-rifle-hp349-sk-sp006-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 6,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-piececool-sung-truong-m16a1-86-manh-m16a1-assault-rifle-hp349-sk-sp006-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 7,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-rokr-sung-truong-ak-47-lq901-sp007-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 7,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-rokr-sung-truong-ak-47-lq901-sp007-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 7,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-rokr-sung-truong-ak-47-lq901-sp007-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 7,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-rokr-sung-truong-ak-47-lq901-sp007-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 8,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-sung-cao-boi-terminator-m870-lq501-sp008-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 8,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-sung-cao-boi-terminator-m870-lq501-sp008-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 8,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-sung-cao-boi-terminator-m870-lq501-sp008-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 8,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-sung-cao-boi-terminator-m870-lq501-sp008-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 9,
                           Image = "mo-hinh-nhua-3d-lap-rap-harry-potter-hogwarts-icons-collectors-edition-6050-3010-manh-sp009-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 9,
                           Image = "mo-hinh-nhua-3d-lap-rap-harry-potter-hogwarts-icons-collectors-edition-6050-3010-manh-sp009-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 9,
                           Image = "mo-hinh-nhua-3d-lap-rap-harry-potter-hogwarts-icons-collectors-edition-6050-3010-manh-sp009-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 9,
                           Image = "mo-hinh-nhua-3d-lap-rap-harry-potter-hogwarts-icons-collectors-edition-6050-3010-manh-sp009-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 10,
                           Image = "mo-hinh-nhua-3d-lap-rap-harry-potter-phuong-hoang-lua-fawkes-86394-597-manh-sp010-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 10,
                           Image = "mo-hinh-nhua-3d-lap-rap-harry-potter-phuong-hoang-lua-fawkes-86394-597-manh-sp010-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 10,
                           Image = "mo-hinh-nhua-3d-lap-rap-harry-potter-phuong-hoang-lua-fawkes-86394-597-manh-sp010-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 10,
                           Image = "mo-hinh-nhua-3d-lap-rap-harry-potter-phuong-hoang-lua-fawkes-86394-597-manh-sp010-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 10,
                           Image = "mo-hinh-nhua-3d-lap-rap-harry-potter-phuong-hoang-lua-fawkes-86394-597-manh-sp010-4.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 11,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-metal-head-harry-potter-the-burrow-sp011-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 11,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-metal-head-harry-potter-the-burrow-sp011-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 11,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-metal-head-harry-potter-the-burrow-sp011-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 11,
                           Image = "mo-hinh-kim-loai-3d-lap-rap-metal-head-harry-potter-the-burrow-sp011-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 12,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-diy-dollhouse-nha-ti-honjoy-s-peninsula-living-room-dg141-sp012-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 12,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-diy-dollhouse-nha-ti-honjoy-s-peninsula-living-room-dg141-sp012-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 12,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-diy-dollhouse-nha-ti-honjoy-s-peninsula-living-room-dg141-sp012-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 12,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-diy-dollhouse-nha-ti-honjoy-s-peninsula-living-room-dg141-sp012-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 13,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-rolife-bubble-bath-bathroom-ds018-sp013-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 13,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-rolife-bubble-bath-bathroom-ds018-sp013-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 13,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-rolife-bubble-bath-bathroom-ds018-sp013-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 13,
                           Image = "mo-hinh-go-3d-lap-rap-robotime-rolife-bubble-bath-bathroom-ds018-sp013-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 14,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-de-havilland-tiger-moth-sp014-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 14,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-de-havilland-tiger-moth-sp014-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 14,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-de-havilland-tiger-moth-sp014-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 14,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-de-havilland-tiger-moth-sp014-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 15,
                           Image = "mo-hinh-nhua-3d-lap-rap-game-of-thrones-con-rong-bang-viserion-9902-1889-manh-sp015-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 15,
                           Image = "mo-hinh-nhua-3d-lap-rap-game-of-thrones-con-rong-bang-viserion-9902-1889-manh-sp015-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 15,
                           Image = "mo-hinh-nhua-3d-lap-rap-game-of-thrones-con-rong-bang-viserion-9902-1889-manh-sp015-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 15,
                           Image = "mo-hinh-nhua-3d-lap-rap-game-of-thrones-con-rong-bang-viserion-9902-1889-manh-sp015-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 15,
                           Image = "mo-hinh-nhua-3d-lap-rap-game-of-thrones-con-rong-bang-viserion-9902-1889-manh-sp015-4.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 16,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-saint-louis-sp016-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 16,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-saint-louis-sp016-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 16,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-saint-louis-sp016-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 16,
                           Image = "mo-hinh-kim-loai-lap-rap-3d-metal-mosaic-may-bay-saint-louis-sp016-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 17,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-triceratops-ds1052h-44-manh-sp017-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 17,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-triceratops-ds1052h-44-manh-sp017-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 17,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-triceratops-ds1052h-44-manh-sp017-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 17,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-triceratops-ds1052h-44-manh-sp017-3.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 18,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-tyrannosaurus-rex-ds1051h-52-manh-sp018-0.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 18,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-tyrannosaurus-rex-ds1051h-52-manh-sp018-1.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 18,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-tyrannosaurus-rex-ds1051h-52-manh-sp018-2.jpg"
                       },
                       new ProductsImage
                       {
                           ProductId = 18,
                           Image = "mo-hinh-giay-3d-lap-rap-cubicfun-tyrannosaurus-rex-ds1051h-52-manh-sp018-3.jpg"
                       }
                       );
                    context.SaveChanges();
                }
                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(
                        new Order
                        {
                            OrderCode = "ORD001",
                            Fullname = "Đỗ Đình Duy",
                            Email = "duy2004.gi@gmail.com",
                            Phone = "0123456789",
                            Address = "1/4 đường số 12, Phường Hiệp Bình Chánh, TP. Thủ Đức, TP. HCM",
                            CreatedAt = DateTime.Now.AddDays(-5),
                            TotalAmount = 430000,
                            PaymentMethod = true,
                            Status = 1,
                            AccountId = 1 // Tham chiếu đến Account đầu tiên
                        },
                        new Order
                        {
                            OrderCode = "ORD002",
                            Fullname = "Lê Bá Hoàng Ánh",
                            Email = "hoanganh2004@gmail.com",
                            Phone = "0123456789",
                            Address = "1/4 đường số 12, Phường Hiệp Bình Chánh, TP. Thủ Đức, TP. HCM",
                            CreatedAt = DateTime.Now.AddDays(-3),
                            TotalAmount = 215000,
                            PaymentMethod = false,
                            Status = 2,
                            AccountId = 2 // Tham chiếu đến Account thứ hai
                        },
                         new Order
                         {
                             OrderCode = "ORD003",
                             Fullname = "Nguyễn Văn C",
                             Email = "nguyenvanc@example.com",
                             Phone = "0123456789",
                             Address = "12 Nguyễn Trãi, Quận 1, TP. HCM",
                             CreatedAt = DateTime.Now.AddDays(-2),
                             TotalAmount = 700000,
                             PaymentMethod = true,
                             Status = 1,
                             AccountId = 3 // Tham chiếu đến Account thứ ba
                         },
                        new Order
                        {
                            OrderCode = "ORD004",
                            Fullname = "Trần Thị D",
                            Email = "tranthid@example.com",
                            Phone = "0987654321",
                            Address = "56 Phạm Văn Đồng, TP. Thủ Đức, TP. HCM",
                            CreatedAt = DateTime.Now.AddDays(-1),
                            TotalAmount = 400000,
                            PaymentMethod = false,
                            Status = 2,
                            AccountId = 4 // Tham chiếu đến Account thứ tư
                        }

                    );
                    context.SaveChanges();
                }
                if (!context.DetailOrders.Any())
                {
                    context.DetailOrders.AddRange(
                        new DetailOrder
                        {
                            OrderId = 1, // Tham chiếu đến đơn hàng đầu tiên (ORD001)
                            ProductId = 1, // Tham chiếu đến sản phẩm đầu tiên
                            Quantity = 2,
                            TotalPrice = 430000 // Tổng tiền: 215000 * 2
                        },
                        new DetailOrder
                        {
                            OrderId = 2, // Tham chiếu đến đơn hàng thứ hai (ORD002)
                            ProductId = 1, // Tham chiếu đến sản phẩm đầu tiên
                            Quantity = 1,
                            TotalPrice = 215000 // Giá của sản phẩm
                        },
                         new DetailOrder
                         {
                             OrderId = 3, // Tham chiếu đến đơn hàng thứ ba (ORD003)
                             ProductId = 2, // Tham chiếu đến sản phẩm thứ hai
                             Quantity = 2,
                             TotalPrice = 500000 // Tổng tiền: 250000 * 2
                         },
                        new DetailOrder
                        {
                            OrderId = 3,
                            ProductId = 3, // Tham chiếu đến sản phẩm thứ ba
                            Quantity = 1,
                            TotalPrice = 200000 // Giá của sản phẩm
                        },
                        // Chi tiết cho ORD004
                        new DetailOrder
                        {
                            OrderId = 4, // Tham chiếu đến đơn hàng thứ tư (ORD004)
                            ProductId = 4, // Tham chiếu đến sản phẩm thứ tư
                            Quantity = 2,
                            TotalPrice = 300000 // Tổng tiền: 150000 * 2
                        },
                        new DetailOrder
                        {
                            OrderId = 4,
                            ProductId = 5, // Tham chiếu đến sản phẩm thứ năm
                            Quantity = 1,
                            TotalPrice = 100000 // Giá của sản phẩm
                        }

                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
