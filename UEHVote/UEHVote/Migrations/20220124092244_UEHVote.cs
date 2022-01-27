using Microsoft.EntityFrameworkCore.Migrations;

namespace UEHVote.Migrations
{
    public partial class UEHVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Ban Tổ chức - Xây dựng Đoàn", 0 },
                    { 29, "Câu lạc bộ Võ thuật", 0 },
                    { 30, "Câu lạc bộ Chuyện to nhỏ", 0 },
                    { 31, "Câu lạc bộ Dynamic", 0 },
                    { 32, "Đội Công tác xã hội", 0 },
                    { 33, "Đội Văn nghệ xung kích", 0 },
                    { 34, "Đội Cộng tác viên", 0 },
                    { 35, "Nhóm Truyền thông Sinh viên - S Communications", 0 },
                    { 36, "Câu lạc bộ Bất động sản - REC", 0 },
                    { 37, "Câu lạc bộ Chuyên viên Nhân sự Tập sự - HuReA", 0 },
                    { 38, "Câu lạc bộ Chứng khoán - SCUE", 0 },
                    { 28, "Câu lạc bộ Tiếng Pháp - CFE", 0 },
                    { 39, "Câu lạc bộ Công nghệ Kinh tế - ET Group", 0 },
                    { 41, "Câu lạc bộ Kinh doanh quốc tế - IBC", 0 },
                    { 42, "Câu lạc bộ Nghiên cứu Kinh tế Trẻ - YoRE", 0 },
                    { 43, "Câu lạc bộ Nhân Sự Khởi Nghiệp - HR Startup", 0 },
                    { 44, "Câu lạc bộ Pháp lý", 0 },
                    { 45, "Câu lạc bộ Thương mại - IC", 0 },
                    { 46, "Câu lạc bộ Tiếng Anh - Apple Club", 0 },
                    { 47, "Câu lạc bộ Lý luận trẻ", 0 },
                    { 48, "Nhóm Hỗ Trợ Sinh Viên - SSG", 0 },
                    { 49, "Nhóm Sinh viên Nghiên cứu Marketing - Margroup", 0 },
                    { 50, "Nhóm Sinh Viên Nghiên Cứu Tài Chính - SFR", 0 },
                    { 40, "Câu lạc bộ Kế toán - Kiểm toán A²C", 0 },
                    { 27, "Câu lạc bộ Guitar - UEHG", 0 },
                    { 26, "Câu lạc bộ Giai điệu trẻ", 0 },
                    { 25, "Câu lạc bộ Dân ca", 0 },
                    { 2, "Ban Phong trào - Tình nguyện", 0 },
                    { 3, "Ban Học tập - Nghiên cứu khoa học - Quan hệ quốc tế", 0 },
                    { 4, "Ban Tổ chức - Xây dựng Hội", 0 },
                    { 5, "Ban Tình nguyện - Hỗ trợ sinh viên", 0 },
                    { 6, "Khoa Luật", 0 },
                    { 7, "Khoa Kế toán", 0 },
                    { 8, "Khoa Kinh tế", 0 },
                    { 9, "Khoa Khoa học xã hội", 0 },
                    { 10, "Khoa Ngân hàng", 0 },
                    { 11, "Khoa Ngoại ngữ", 0 },
                    { 12, "Khoa Quản lý nhà nước", 0 },
                    { 13, "Khoa Quản trị", 0 },
                    { 14, "Khoa Tài chính", 0 },
                    { 15, "Khoa Tài chính công", 0 },
                    { 16, "Khoa Công nghệ thông tin kinh doanh", 0 }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 17, "Khoa Kinh doanh quốc tế - Marketing", 0 },
                    { 18, "Khoa Toán - Thống kê", 0 },
                    { 19, "Viện Du lịch", 0 },
                    { 20, "Viện Đào tạo quốc tế", 0 },
                    { 21, "KTX 135 Trần Hưng Đạo", 0 },
                    { 22, "KT 43-45 Nguyễn Chí Thanh", 0 },
                    { 23, "Câu lạc bộ Anh Văn - BELL", 0 },
                    { 24, "Câu lạc bộ Bóng chuyền", 0 },
                    { 51, "Nhóm Sinh Viên Nghiên Cứu Thuế - TaxGroup", 0 },
                    { 52, "Nhóm Sinh viên Nghiên cứu Du lịch - Travel Group", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 52);
        }
    }
}
