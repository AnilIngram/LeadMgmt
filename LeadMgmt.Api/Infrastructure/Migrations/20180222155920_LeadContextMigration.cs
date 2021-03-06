﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LeadMgmt.Api.Infrastructure.Migrations
{
    public partial class LeadContextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BestTimeToCall = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    LeadType = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lead");
        }
    }
}
