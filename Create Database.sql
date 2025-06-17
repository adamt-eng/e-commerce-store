CREATE TABLE [dbo].[Customer] (
    [Customer_ID]   INT           IDENTITY (1, 1) NOT NULL,
    [First_Name]    VARCHAR (50)  NOT NULL,
    [Last_Name]     VARCHAR (50)  NOT NULL,
    [Email]         VARCHAR (100) COLLATE Latin1_General_CS_AS NOT NULL,
    [Pass_Hashed]   VARCHAR (64)  COLLATE Latin1_General_CS_AS NOT NULL,
    [Phone_Number]  VARCHAR (20)  NULL,
    [Date_Of_Birth] DATE          NULL,
    [Created_On]    DATETIME      DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Customer_ID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

CREATE TABLE [dbo].[Cart] (
    [Cart_ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Customer_ID]      INT             NOT NULL,
    [Cart_Expiry_Date] DATETIME        NULL,
    [Total_Price]      DECIMAL (10, 2) DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Cart_ID] ASC),
    UNIQUE NONCLUSTERED ([Customer_ID] ASC),
    FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customer] ([Customer_ID])
);

CREATE TABLE [dbo].[Category] (
    [Category_ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Category_Name]        VARCHAR (100)  NOT NULL,
    [Category_Description] VARCHAR (1500) NULL,
    PRIMARY KEY CLUSTERED ([Category_ID] ASC)
);

CREATE TABLE [dbo].[Seller] (
    [Seller_ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Seller_Name]    VARCHAR (100) NOT NULL,
    [Seller_Email]   VARCHAR (100) COLLATE Latin1_General_CS_AS NOT NULL,
    [Pass_Hashed]    VARCHAR (64)  COLLATE Latin1_General_CS_AS NOT NULL,
    [Phone_Number]   VARCHAR (20)  NULL,
    [Seller_Address] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Seller_ID] ASC),
    UNIQUE NONCLUSTERED ([Seller_Email] ASC)
);

CREATE TABLE [dbo].[Product] (
    [Product_ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Product_Name]        VARCHAR (100)   NOT NULL,
    [Price]               DECIMAL (10, 2) NOT NULL,
    [Product_Description] VARCHAR (MAX)   NULL,
    [Quantity_In_Stock]   INT             DEFAULT ((0)) NOT NULL,
    [Published_At]        DATETIME        DEFAULT (getdate()) NULL,
    [Category_ID]         INT             NULL,
    [Seller_ID]           INT             NOT NULL,
    [Image_Link]          VARCHAR (2048)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Product_ID] ASC),
    FOREIGN KEY ([Seller_ID]) REFERENCES [dbo].[Seller] ([Seller_ID]),
    FOREIGN KEY ([Category_ID]) REFERENCES [dbo].[Category] ([Category_ID]),
    CHECK ([Price] > (0)),
    CHECK ([Quantity_In_Stock] >= (0))
);

CREATE TABLE [dbo].[Added_To] (
    [Cart_ID]    INT NOT NULL,
    [Product_ID] INT NOT NULL,
    [Quantity]   INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Cart_ID] ASC, [Product_ID] ASC),
    FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Product] ([Product_ID]),
    FOREIGN KEY ([Cart_ID]) REFERENCES [dbo].[Cart] ([Cart_ID]),
    CHECK ([Quantity] > (0))
);

CREATE TABLE [dbo].[Admin] (
    [Admin_ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Admin_Name]   VARCHAR (100) NOT NULL,
    [Admin_Email]  VARCHAR (100) COLLATE Latin1_General_CS_AS NOT NULL,
    [Pass_Hashed]  VARCHAR (64)  COLLATE Latin1_General_CS_AS NOT NULL,
    [Phone_Number] VARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([Admin_ID] ASC),
    UNIQUE NONCLUSTERED ([Admin_Email] ASC)
);

CREATE TABLE [dbo].[Customer_Address] (
    [Address_ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Customer_ID]         INT            NOT NULL,
    [Label]               NVARCHAR (50)  NOT NULL,
    [City]                NVARCHAR (100) NOT NULL,
    [Address_Description] NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Address_ID] ASC, [Customer_ID] ASC),
    FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customer] ([Customer_ID])
);

CREATE TABLE [dbo].[Order] (
    [Order_ID]            INT             IDENTITY (1, 1) NOT NULL,
    [Order_Date]          DATETIME        DEFAULT (getdate()) NULL,
    [Order_Status]        NVARCHAR (50)   DEFAULT ('Pending') NOT NULL,
    [Shipping_Address_ID] INT             NOT NULL,
    [Billing_Address_ID]  INT             NOT NULL,
    [Customer_ID]         INT             NOT NULL,
    [Total_Price]         DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Order_ID] ASC),
    FOREIGN KEY ([Shipping_Address_ID], [Customer_ID]) REFERENCES [dbo].[Customer_Address] ([Address_ID], [Customer_ID]),
    FOREIGN KEY ([Billing_Address_ID], [Customer_ID]) REFERENCES [dbo].[Customer_Address] ([Address_ID], [Customer_ID]),
    FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customer] ([Customer_ID]),
    CHECK ([Order_Status] = 'Cancelled' OR [Order_Status] = 'Delivered' OR [Order_Status] = 'Shipped' OR [Order_Status] = 'Processing' OR [Order_Status] = 'Pending'),
    CHECK ([Total_Price] > (0))
);

CREATE TABLE [dbo].[order_contains_product] (
    [Order_ID]   INT             NOT NULL,
    [Product_ID] INT             NOT NULL,
    [Quantity]   INT             NOT NULL,
    [Unit_Price] DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Order_ID] ASC, [Product_ID] ASC),
    FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Product] ([Product_ID]),
    FOREIGN KEY ([Order_ID]) REFERENCES [dbo].[Order] ([Order_ID]),
    CHECK ([Quantity] > (0)),
    CHECK ([Unit_Price] > (0))
);

CREATE TABLE [dbo].[Payment] (
    [Card_Number]      VARCHAR(20)  NOT NULL,
    [CardHolder_Name]  VARCHAR(100) NOT NULL,
    [Card_Expiry_Date] DATE         NOT NULL,
    [Customer_ID]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Customer_ID], [Card_Number]),
    FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[Customer]([Customer_ID])
);
