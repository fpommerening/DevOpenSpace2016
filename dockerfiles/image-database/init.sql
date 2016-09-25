Create Database "imagedata";

use imagedata;



CREATE TABLE "User" (
    "Id" uuid NOT NULL,
    "Login" text NOT NULL,
    "Password" text NOT NULL,
    CONSTRAINT "PK_User" PRIMARY KEY ("Id")
);

