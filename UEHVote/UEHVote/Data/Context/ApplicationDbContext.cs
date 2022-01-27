using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using UEHVote.Models;

namespace UEHVote.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<VotedCandidate>().HasOne(x => x.Vote).WithMany(x => x.VotedCandidates).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Organization>().HasData(					
                new Organization { Id = 1, Name = "Ban Tổ chức - Xây dựng Đoàn" },					
                new Organization { Id = 2, Name = "Ban Phong trào - Tình nguyện" },					
                new Organization { Id = 3, Name = "Ban Học tập - Nghiên cứu khoa học - Quan hệ quốc tế" },					
                new Organization { Id = 4, Name = "Ban Tổ chức - Xây dựng Hội" },					
                new Organization { Id = 5, Name = "Ban Tình nguyện - Hỗ trợ sinh viên" },					
                new Organization { Id = 6, Name = "Khoa Luật" },					
                new Organization { Id = 7, Name = "Khoa Kế toán" },					
                new Organization { Id = 8, Name = "Khoa Kinh tế" },					
                new Organization { Id = 9, Name = "Khoa Khoa học xã hội" },					
                new Organization { Id = 10, Name = "Khoa Ngân hàng" },					
                new Organization { Id = 11, Name = "Khoa Ngoại ngữ" },					
                new Organization { Id = 12, Name = "Khoa Quản lý nhà nước" },					
                new Organization { Id = 13, Name = "Khoa Quản trị" },					
                new Organization { Id = 14, Name = "Khoa Tài chính" },					
                new Organization { Id = 15, Name = "Khoa Tài chính công" },					
                new Organization { Id = 16, Name = "Khoa Công nghệ thông tin kinh doanh" },					
                new Organization { Id = 17, Name = "Khoa Kinh doanh quốc tế - Marketing" },					
                new Organization { Id = 18, Name = "Khoa Toán - Thống kê" },					
                new Organization { Id = 19, Name = "Viện Du lịch" },					
                new Organization { Id = 20, Name = "Viện Đào tạo quốc tế" },					
                new Organization { Id = 21, Name = "KTX 135 Trần Hưng Đạo" },					
                new Organization { Id = 22, Name = "KT 43-45 Nguyễn Chí Thanh" },					
                new Organization { Id = 23, Name = "Câu lạc bộ Anh Văn - BELL" },					
                new Organization { Id = 24, Name = "Câu lạc bộ Bóng chuyền" },					
                new Organization { Id = 25, Name = "Câu lạc bộ Dân ca" },					
                new Organization { Id = 26, Name = "Câu lạc bộ Giai điệu trẻ" },					
                new Organization { Id = 27, Name = "Câu lạc bộ Guitar - UEHG" },					
                new Organization { Id = 28, Name = "Câu lạc bộ Tiếng Pháp - CFE" },					
                new Organization { Id = 29, Name = "Câu lạc bộ Võ thuật" },					
                new Organization { Id = 30, Name = "Câu lạc bộ Chuyện to nhỏ" },					
                new Organization { Id = 31, Name = "Câu lạc bộ Dynamic" },					
                new Organization { Id = 32, Name = "Đội Công tác xã hội" },					
                new Organization { Id = 33, Name = "Đội Văn nghệ xung kích" },					
                new Organization { Id = 34, Name = "Đội Cộng tác viên" },					
                new Organization { Id = 35, Name = "Nhóm Truyền thông Sinh viên - S Communications" },					
                new Organization { Id = 36, Name = "Câu lạc bộ Bất động sản - REC" },					
                new Organization { Id = 37, Name = "Câu lạc bộ Chuyên viên Nhân sự Tập sự - HuReA" },					
                new Organization { Id = 38, Name = "Câu lạc bộ Chứng khoán - SCUE" },					
                new Organization { Id = 39, Name = "Câu lạc bộ Công nghệ Kinh tế - ET Group" },					
                new Organization { Id = 40, Name = "Câu lạc bộ Kế toán - Kiểm toán A²C" },					
                new Organization { Id = 41, Name = "Câu lạc bộ Kinh doanh quốc tế - IBC" },					
                new Organization { Id = 42, Name = "Câu lạc bộ Nghiên cứu Kinh tế Trẻ - YoRE" },					
                new Organization { Id = 43, Name = "Câu lạc bộ Nhân Sự Khởi Nghiệp - HR Startup" },					
                new Organization { Id = 44, Name = "Câu lạc bộ Pháp lý" },					
                new Organization { Id = 45, Name = "Câu lạc bộ Thương mại - IC" },					
                new Organization { Id = 46, Name = "Câu lạc bộ Tiếng Anh - Apple Club" },					
                new Organization { Id = 47, Name = "Câu lạc bộ Lý luận trẻ" },					
                new Organization { Id = 48, Name = "Nhóm Hỗ Trợ Sinh Viên - SSG" },					
                new Organization { Id = 49, Name = "Nhóm Sinh viên Nghiên cứu Marketing - Margroup" },					
                new Organization { Id = 50, Name = "Nhóm Sinh Viên Nghiên Cứu Tài Chính - SFR" },					
                new Organization { Id = 51, Name = "Nhóm Sinh Viên Nghiên Cứu Thuế - TaxGroup" },					
                new Organization { Id = 52, Name = "Nhóm Sinh viên Nghiên cứu Du lịch - Travel Group" }					
            );					
        }
        public DbSet<ActivityImage> ActivityImages { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateImage> CandidateImages { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<VotedCandidate> VotedCandidates { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
