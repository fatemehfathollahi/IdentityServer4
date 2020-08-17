using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Plus.Infrastructure.IdentityServer.Migrations
{
    public partial class MyfirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlusApiResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusApiResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlusClients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(nullable: false),
                    ClientId = table.Column<string>(maxLength: 200, nullable: false),
                    ProtocolType = table.Column<string>(maxLength: 200, nullable: false),
                    RequireClientSecret = table.Column<bool>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>(nullable: false),
                    AllowRememberConsent = table.Column<bool>(nullable: false),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(nullable: false),
                    RequirePkce = table.Column<bool>(nullable: false),
                    AllowPlainTextPkce = table.Column<bool>(nullable: false),
                    AllowAccessTokensViaBrowser = table.Column<bool>(nullable: false),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(nullable: false),
                    AllowOfflineAccess = table.Column<bool>(nullable: false),
                    IdentityTokenLifetime = table.Column<int>(nullable: false),
                    AccessTokenLifetime = table.Column<int>(nullable: false),
                    AuthorizationCodeLifetime = table.Column<int>(nullable: false),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(nullable: false),
                    SlidingRefreshTokenLifetime = table.Column<int>(nullable: false),
                    RefreshTokenUsage = table.Column<int>(nullable: false),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(nullable: false),
                    RefreshTokenExpiration = table.Column<int>(nullable: false),
                    AccessTokenType = table.Column<int>(nullable: false),
                    EnableLocalLogin = table.Column<bool>(nullable: false),
                    IncludeJwtId = table.Column<bool>(nullable: false),
                    AlwaysSendClientClaims = table.Column<bool>(nullable: false),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    UserSsoLifetime = table.Column<int>(nullable: true),
                    UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(nullable: false),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlusIdentityResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusIdentityResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlusApiClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusApiClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusApiClaims_PlusApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "PlusApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusApiProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusApiProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusApiProperties_PlusApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "PlusApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusApiScopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<bool>(nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusApiScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusApiScopes_PlusApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "PlusApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusApiSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ApiResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusApiSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusApiSecrets_PlusApiResources_ApiResourceId",
                        column: x => x.ApiResourceId,
                        principalTable: "PlusApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusClientClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusClientClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusClientClaims_PlusClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PlusClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusClientCorsOrigins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(maxLength: 150, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusClientCorsOrigins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusClientCorsOrigins_PlusClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PlusClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusClientGrantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrantType = table.Column<string>(maxLength: 250, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusClientGrantTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusClientGrantTypes_PlusClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PlusClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusClientIdPRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusClientIdPRestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusClientIdPRestrictions_PlusClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PlusClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusClientPostLogoutRedirectUris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostLogoutRedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusClientPostLogoutRedirectUris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusClientPostLogoutRedirectUris_PlusClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PlusClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusClientProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusClientProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusClientProperties_PlusClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PlusClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusClientRedirectUris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedirectUri = table.Column<string>(maxLength: 2000, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusClientRedirectUris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusClientRedirectUris_PlusClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PlusClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusClientScopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusClientScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusClientScopes_PlusClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PlusClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusClientSecrets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000, nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusClientSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusClientSecrets_PlusClients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "PlusClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusIdentityClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    IdentityResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusIdentityClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusIdentityClaims_PlusIdentityResources_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalTable: "PlusIdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusIdentityResourdeProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 250, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    IdentityResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusIdentityResourdeProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusIdentityResourdeProperties_PlusIdentityResources_IdentityResourceId",
                        column: x => x.IdentityResourceId,
                        principalTable: "PlusIdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlusApiScopeClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    ApiScopeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusApiScopeClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusApiScopeClaims_PlusApiScopes_ApiScopeId",
                        column: x => x.ApiScopeId,
                        principalTable: "PlusApiScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlusApiClaims_ApiResourceId",
                table: "PlusApiClaims",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusApiProperties_ApiResourceId",
                table: "PlusApiProperties",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusApiResources_Name",
                table: "PlusApiResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlusApiScopeClaims_ApiScopeId",
                table: "PlusApiScopeClaims",
                column: "ApiScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusApiScopes_ApiResourceId",
                table: "PlusApiScopes",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusApiScopes_Name",
                table: "PlusApiScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlusApiSecrets_ApiResourceId",
                table: "PlusApiSecrets",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusClientClaims_ClientId",
                table: "PlusClientClaims",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusClientCorsOrigins_ClientId",
                table: "PlusClientCorsOrigins",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusClientGrantTypes_ClientId",
                table: "PlusClientGrantTypes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusClientIdPRestrictions_ClientId",
                table: "PlusClientIdPRestrictions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusClientPostLogoutRedirectUris_ClientId",
                table: "PlusClientPostLogoutRedirectUris",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusClientProperties_ClientId",
                table: "PlusClientProperties",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusClientRedirectUris_ClientId",
                table: "PlusClientRedirectUris",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusClients_ClientId",
                table: "PlusClients",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlusClientScopes_ClientId",
                table: "PlusClientScopes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusClientSecrets_ClientId",
                table: "PlusClientSecrets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusIdentityClaims_IdentityResourceId",
                table: "PlusIdentityClaims",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusIdentityResources_Name",
                table: "PlusIdentityResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlusIdentityResourdeProperties_IdentityResourceId",
                table: "PlusIdentityResourdeProperties",
                column: "IdentityResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlusApiClaims");

            migrationBuilder.DropTable(
                name: "PlusApiProperties");

            migrationBuilder.DropTable(
                name: "PlusApiScopeClaims");

            migrationBuilder.DropTable(
                name: "PlusApiSecrets");

            migrationBuilder.DropTable(
                name: "PlusClientClaims");

            migrationBuilder.DropTable(
                name: "PlusClientCorsOrigins");

            migrationBuilder.DropTable(
                name: "PlusClientGrantTypes");

            migrationBuilder.DropTable(
                name: "PlusClientIdPRestrictions");

            migrationBuilder.DropTable(
                name: "PlusClientPostLogoutRedirectUris");

            migrationBuilder.DropTable(
                name: "PlusClientProperties");

            migrationBuilder.DropTable(
                name: "PlusClientRedirectUris");

            migrationBuilder.DropTable(
                name: "PlusClientScopes");

            migrationBuilder.DropTable(
                name: "PlusClientSecrets");

            migrationBuilder.DropTable(
                name: "PlusIdentityClaims");

            migrationBuilder.DropTable(
                name: "PlusIdentityResourdeProperties");

            migrationBuilder.DropTable(
                name: "PlusApiScopes");

            migrationBuilder.DropTable(
                name: "PlusClients");

            migrationBuilder.DropTable(
                name: "PlusIdentityResources");

            migrationBuilder.DropTable(
                name: "PlusApiResources");
        }
    }
}
