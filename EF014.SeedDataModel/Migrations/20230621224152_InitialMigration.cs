using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF014.SeedDataModel.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OfficeName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    OfficeLocation = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUN = table.Column<bool>(type: "bit", nullable: false),
                    MON = table.Column<bool>(type: "bit", nullable: false),
                    TUE = table.Column<bool>(type: "bit", nullable: false),
                    WED = table.Column<bool>(type: "bit", nullable: false),
                    THU = table.Column<bool>(type: "bit", nullable: false),
                    FRI = table.Column<bool>(type: "bit", nullable: false),
                    SAT = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coporates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coporates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coporates_Participants_Id",
                        column: x => x.Id,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfGraduation = table.Column<int>(type: "int", nullable: false),
                    IsIntern = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individuals_Participants_Id",
                        column: x => x.Id,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SectionName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sections_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.SectionId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_Enrollments_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "Price" },
                values: new object[,]
                {
                    { 1, "Mathematics", 1000.00m },
                    { 2, "Physics", 2000.00m },
                    { 3, "Chemistry", 1500.00m },
                    { 4, "Biology", 1200.00m },
                    { 5, "CS-50", 3000.00m }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "OfficeLocation", "OfficeName" },
                values: new object[,]
                {
                    { 1, "Building A", "Off_05" },
                    { 2, "Building B", "Off_12" },
                    { 3, "Administration", "Off_32" },
                    { 4, "IT Department", "Off_44" },
                    { 5, "IT Department", "Off_43" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "FName", "LName" },
                values: new object[,]
                {
                    { 1, "Fatima", "Ali" },
                    { 2, "Noor", "Saleh" },
                    { 3, "Omar", "Youssef" },
                    { 4, "Huda", "Ahmed" },
                    { 5, "Amira", "Tariq" },
                    { 6, "Zainab", "Ismail" },
                    { 7, "Yousef", "Farid" },
                    { 8, "Layla", "Mustafa" },
                    { 9, "Mohammed", "Adel" },
                    { 10, "Samira", "Nabil" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "FRI", "MON", "SAT", "SUN", "THU", "TUE", "Title", "WED" },
                values: new object[,]
                {
                    { 1, false, true, false, true, true, true, "Daily", true },
                    { 2, false, false, false, true, true, true, "DayAfterDay", false },
                    { 3, false, true, false, false, false, false, "TwiceAWeek", true },
                    { 4, true, false, true, false, false, false, "Weekend", false },
                    { 5, true, true, true, true, true, true, "Compact", true }
                });

            migrationBuilder.InsertData(
                table: "Coporates",
                columns: new[] { "Id", "Company", "JobTitle" },
                values: new object[,]
                {
                    { 2, "ABC", "Developer" },
                    { 4, "ABC", "QA" },
                    { 7, "EFG", "Developer" },
                    { 8, "EFG", "QA" }
                });

            migrationBuilder.InsertData(
             table: "Instructors",
             columns: new[] { "Id", "FName", "LName", "OfficeId" },
             values: new object[,]
             {
                    { 1, "Ahmed", "Abdullah", 1 },
                    { 2, "Yasmeen", "Mohammed", 2 },
                    { 3, "Khalid", "Hassan", 3 },
                    { 4, "Nadia", "Ali", 4 },
                    { 5, "Omar", "Ibrahim", 5 }
             });

            // Seeding Section  to bypass Owned Entity type limitations
            migrationBuilder.InsertData(
              table: "Sections",
              columns: new[] { "Id", "SectionName", "CourseId", "InstructorId", "ScheduleId", "StartTime", "EndTime" },
              values: new object[,]
              {
                 { 1,  "S_MA1", 1, 1, 1, TimeSpan.Parse("08:00:00"), TimeSpan.Parse("10:00:00") },
                 { 2,  "S_MA2", 1, 2, 3, TimeSpan.Parse("14:00:00"), TimeSpan.Parse("18:00:00") },
                 { 3,  "S_PH1", 2, 1, 4, TimeSpan.Parse("10:00:00"), TimeSpan.Parse("15:00:00") },
                 { 4,  "S_PH2", 2, 3, 1, TimeSpan.Parse("10:00:00"), TimeSpan.Parse("12:00:00") },
                 { 5,  "S_CH1", 3, 2, 1, TimeSpan.Parse("16:00:00"), TimeSpan.Parse("18:00:00") },
                 { 6,  "S_CH2", 3, 3, 2, TimeSpan.Parse("08:00:00"), TimeSpan.Parse("10:00:00") },
                 { 7,  "S_BI1", 4, 4, 3, TimeSpan.Parse("11:00:00"), TimeSpan.Parse("14:00:00") },
                 { 8,  "S_BI2", 4, 5, 4, TimeSpan.Parse("10:00:00"), TimeSpan.Parse("14:00:00") },
                 { 9,  "S_CS1", 5, 4, 4, TimeSpan.Parse("16:00:00"), TimeSpan.Parse("18:00:00") },
                 { 10, "S_CS2", 5, 5, 3, TimeSpan.Parse("12:00:00"), TimeSpan.Parse("15:00:00") },
                 { 11, "S_CS3", 5, 4, 5, TimeSpan.Parse("09:00:00"), TimeSpan.Parse("11:00:00") }
              }
            );

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "ParticipantId", "SectionId" },
                values: new object[,]
                {
                    { 1, 6 },
                    { 2, 6 },
                    { 3, 7 },
                    { 4, 7 },
                    { 5, 8 },
                    { 6, 8 },
                    { 7, 9 },
                    { 8, 9 },
                    { 9, 10 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Individuals",
                columns: new[] { "Id", "IsIntern", "University", "YearOfGraduation" },
                values: new object[,]
                {
                    { 1, false, "XYZ", 2024 },
                    { 3, true, "POQ", 2023 },
                    { 5, false, "POQ", 2025 },
                    { 6, true, "POQ", 2023 },
                    { 9, false, "XYZ", 2024 },
                    { 10, false, "XYZ", 2024 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ParticipantId",
                table: "Enrollments",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_OfficeId",
                table: "Instructors",
                column: "OfficeId",
                unique: true,
                filter: "[OfficeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_InstructorId",
                table: "Sections",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ScheduleId",
                table: "Sections",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coporates");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
