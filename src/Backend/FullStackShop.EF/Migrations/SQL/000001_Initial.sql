﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "ProductsCategories" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    CONSTRAINT "PK_ProductsCategories" PRIMARY KEY ("Id")
);

CREATE TABLE "Users" (
    _id character varying(256) NOT NULL,
    "CreatedOn" timestamp NOT NULL,
    _email character varying(64) NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY (_id)
);

CREATE TABLE "Products" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "_categoryId" integer NOT NULL,
    _description character varying(2048),
    _name character varying(64) NOT NULL,
    _price numeric(5,2),
    CONSTRAINT "PK_Products" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Products_ProductsCategories__categoryId" FOREIGN KEY ("_categoryId") REFERENCES "ProductsCategories" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Products__categoryId" ON "Products" ("_categoryId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231203023614_Initial', '8.0.0');

COMMIT;

