USE [master]
GO
/****** Object:  Database [Ebay_Api]    Script Date: 11/1/2018 6:49:26 PM ******/
CREATE DATABASE [Ebay_Api]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ebay_Api', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\Ebay_Api.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Ebay_Api_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS2012\MSSQL\DATA\Ebay_Api_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Ebay_Api] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ebay_Api].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ebay_Api] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ebay_Api] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ebay_Api] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ebay_Api] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ebay_Api] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ebay_Api] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ebay_Api] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Ebay_Api] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ebay_Api] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ebay_Api] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ebay_Api] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ebay_Api] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ebay_Api] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ebay_Api] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ebay_Api] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ebay_Api] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ebay_Api] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ebay_Api] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ebay_Api] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ebay_Api] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ebay_Api] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ebay_Api] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ebay_Api] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ebay_Api] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Ebay_Api] SET  MULTI_USER 
GO
ALTER DATABASE [Ebay_Api] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ebay_Api] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ebay_Api] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ebay_Api] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Ebay_Api]
GO
/****** Object:  Table [dbo].[BulkMigrateListing]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BulkMigrateListing](
	[StatusCode] [nchar](30) NULL,
	[ListingId] [int] NULL,
	[MarketplaceId] [nchar](30) NULL,
	[ItemGroupKey] [nchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BulkPriceQuality]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BulkPriceQuality](
	[SKU] [nchar](50) NULL,
	[OfferId] [nchar](30) NULL,
	[offerStatus] [nchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreateFulfillmentPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreateFulfillmentPolicy](
	[Name] [nvarchar](50) NULL,
	[MarketPlaceId] [nvarchar](50) NULL,
	[HandlingTimeValue] [int] NULL,
	[HandlingTimeUnit] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreateLocation]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreateLocation](
	[AddressLine1] [nchar](50) NULL,
	[AddressLine2] [nchar](30) NULL,
	[City] [nchar](50) NULL,
	[StateOrProvince] [nchar](30) NULL,
	[PostalCode] [nchar](30) NULL,
	[Country] [nchar](30) NULL,
	[LocInstructions] [nchar](30) NULL,
	[Name] [nchar](30) NULL,
	[MarchentStatus] [nchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreateorReplaceItem]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreateorReplaceItem](
	[Condition] [nchar](50) NULL,
	[ShipToLocationAvailability] [nchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreatePaymentPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreatePaymentPolicy](
	[Name] [nvarchar](50) NULL,
	[MarketPlaceId] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[ImmediatePay] [bit] NULL,
	[PaymentPolicyId] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreateReturnPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreateReturnPolicy](
	[Name] [nchar](20) NULL,
	[Description] [nchar](20) NULL,
	[MarketplaceId] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeleteFulfillmentPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeleteFulfillmentPolicy](
	[StatusCode] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeletePaymentPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeletePaymentPolicy](
	[StatusCode] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeleteSalesTaxs]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeleteSalesTaxs](
	[Status] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeeDetails]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeeDetails](
	[FeeDBID] [int] NULL,
	[Currency] [nchar](50) NULL,
	[Value] [nchar](100) NULL,
	[FeeType] [nchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FullfillmentPlolicy_ShippingService]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FullfillmentPlolicy_ShippingService](
	[FulfillmentPoliciesID] [int] NULL,
	[OptionType] [nvarchar](50) NULL,
	[CostType] [nvarchar](50) NULL,
	[SortOrder] [int] NULL,
	[ShippingCarrierCode] [nvarchar](50) NULL,
	[ShippingServiceCode] [nvarchar](50) NULL,
	[ShippingCostValue] [nvarchar](50) NULL,
	[ShippingCostCurrency] [nvarchar](50) NOT NULL,
	[FreeShipping] [bit] NOT NULL,
	[BuyerResponsibleForShipping] [bit] NOT NULL,
	[BuyerResponsibleForPickup] [bit] NOT NULL,
	[InsuranceOffered] [bit] NOT NULL,
	[InsuranceFeeValue] [nvarchar](50) NULL,
	[InsuranceFeeCurrency] [bit] NOT NULL,
	[GlobalShipping] [bit] NOT NULL,
	[PickupDropOff] [bit] NOT NULL,
	[FreightShipping] [bit] NOT NULL,
	[FulfillmentPolicyId] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FullfillPlolicy_CategoryTypes]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FullfillPlolicy_CategoryTypes](
	[FulfillmentPoliciesID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Default] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetFulfillmentPolicies]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetFulfillmentPolicies](
	[Name] [nvarchar](50) NULL,
	[MarketPlaceId] [nvarchar](50) NULL,
	[HandlingTimeValue] [int] NULL,
	[HandlingTimeUnit] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetFulfillmentPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetFulfillmentPolicy](
	[Name] [nvarchar](50) NULL,
	[MarketPlaceId] [nvarchar](50) NULL,
	[HandlingTimeValue] [int] NULL,
	[HandlingTimeUnit] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetFulfillmentPolicyByName]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetFulfillmentPolicyByName](
	[Name] [nvarchar](50) NULL,
	[MarketPlaceId] [nvarchar](50) NULL,
	[HandlingTimeValue] [int] NULL,
	[HandlingTimeUnit] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetInventoryItem]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetInventoryItem](
	[SKU] [nchar](50) NULL,
	[condition] [nchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetInventoryItemGroup]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetInventoryItemGroup](
	[InventoryItemGroupKey] [nchar](50) NULL,
	[Title] [nchar](100) NULL,
	[Description] [nchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetInventoryItems]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetInventoryItems](
	[InventoryReferenceId] [nchar](50) NULL,
	[InventoryReferenceType] [nchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetListingViolations]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetListingViolations](
	[ComplianceType] [nchar](50) NULL,
	[ListingId] [nchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetListingViolationsSummary]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetListingViolationsSummary](
	[ComplianceType] [nchar](50) NULL,
	[ListingCount] [int] NULL,
	[MarketplaceId] [nchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetOffer]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetOffer](
	[OfferId] [nchar](50) NULL,
	[Sku] [nchar](100) NULL,
	[MarketplaceId] [nchar](200) NULL,
	[Format] [nchar](50) NULL,
	[AvailableQuantity] [int] NULL,
	[CategoryId] [nchar](200) NULL,
	[QuantityLimitPerBuyer] [nchar](20) NULL,
	[OfferStatus] [nchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetOffers]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetOffers](
	[OfferId] [nchar](50) NULL,
	[Sku] [nchar](100) NULL,
	[MarketplaceId] [nchar](200) NULL,
	[Format] [nchar](50) NULL,
	[AvailableQuantity] [int] NULL,
	[CategoryId] [nchar](200) NULL,
	[QuantityLimitPerBuyer] [int] NULL,
	[OfferStatus] [nchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetOptedInPrograms]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetOptedInPrograms](
	[ProgramType] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetPaymentPolicies]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetPaymentPolicies](
	[Name] [nvarchar](50) NULL,
	[MarketPlaceId] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetPaymentPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetPaymentPolicy](
	[Name] [nvarchar](50) NULL,
	[MarketPlaceId] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[ImmediatePay] [bit] NULL,
	[PaymentPolicyId] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetPaymentPolicyByName]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetPaymentPolicyByName](
	[Name] [nvarchar](50) NULL,
	[MarketPlaceId] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[ImmediatePay] [bit] NULL,
	[PaymentPolicyId] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetPrivilage]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetPrivilage](
	[Value] [nchar](10) NULL,
	[Currency] [nchar](10) NULL,
	[Quality] [nvarchar](50) NULL,
	[sellerRegistrationCompleted] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetProdCompatibility]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetProdCompatibility](
	[Sku] [nchar](30) NULL,
	[Notes] [nchar](100) NULL,
	[Make] [nchar](30) NULL,
	[Model] [nchar](30) NULL,
	[Engine] [nchar](30) NULL,
	[Trim] [nchar](30) NULL,
	[Year] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetRateTables]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetRateTables](
	[CountryCode] [nchar](10) NULL,
	[Name] [nchar](20) NULL,
	[Locality] [nchar](20) NULL,
	[RateTableId] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetReturnPolicies]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetReturnPolicies](
	[Name] [nchar](20) NULL,
	[Description] [nchar](20) NULL,
	[MarketplaceId] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetReturnPoliciesByName]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetReturnPoliciesByName](
	[Name] [nchar](20) NULL,
	[MarketplaceId] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetReturnPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetReturnPolicy](
	[Name] [nchar](20) NULL,
	[Description] [nchar](20) NULL,
	[MarketplaceId] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetSalesTax]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetSalesTax](
	[SalesTaxJurisdictionId] [nchar](20) NULL,
	[salesTaxPercentage] [nchar](20) NULL,
	[CountryCode] [nchar](10) NULL,
	[ShippingAndHandlingTaxed] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GetSalesTaxes]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GetSalesTaxes](
	[SalesTaxJurisdictionId] [nchar](20) NULL,
	[salesTaxPercentage] [nchar](20) NULL,
	[CountryCode] [nchar](10) NULL,
	[ShippingAndHandlingTaxed] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inventory_ProductDetails]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory_ProductDetails](
	[InventoryDBID] [int] NOT NULL,
	[Description] [nchar](200) NULL,
	[Title] [nchar](100) NULL,
	[Brand] [nchar](100) NULL,
	[Ean] [nchar](50) NULL,
	[ImageUrls] [nchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InventoryLocations]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryLocations](
	[Name] [nchar](50) NULL,
	[MerchantLocationStatus] [nchar](30) NULL,
	[MerchantLocationKey] [nchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ListFees]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListFees](
	[MarketplaceId] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ListingOffer]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListingOffer](
	[OfferDBID] [int] NOT NULL,
	[ListingId] [nchar](50) NULL,
	[ListingStatus] [nchar](100) NULL,
	[SoldQuantity] [nchar](200) NULL,
	[PaymentPolicyId] [nchar](30) NULL,
	[ReturnPolicyId] [nchar](30) NULL,
	[Currency] [nchar](20) NULL,
	[Value] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ListingOffers]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListingOffers](
	[OfferDBID] [int] NOT NULL,
	[ListingId] [nchar](50) NULL,
	[ListingStatus] [nchar](100) NULL,
	[SoldQuantity] [nchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ListingPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListingPolicy](
	[OfferDBID] [int] NOT NULL,
	[PaymentPolicyId] [nchar](30) NULL,
	[ReturnPolicyId] [nchar](30) NULL,
	[Currency] [nchar](20) NULL,
	[Value] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Location_Details]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location_Details](
	[LocationDBID] [int] NOT NULL,
	[LoactionId] [nchar](50) NULL,
	[AddressLine1] [nchar](50) NULL,
	[AddressLine2] [nchar](30) NULL,
	[City] [nchar](50) NULL,
	[StateOrProvince] [nchar](30) NULL,
	[PostalCode] [nchar](30) NULL,
	[Country] [nchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LocationAddress]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationAddress](
	[LocationDBID] [int] NOT NULL,
	[LoactionId] [nchar](50) NULL,
	[City] [nchar](50) NULL,
	[StateOrProvince] [nchar](30) NULL,
	[PostalCode] [nchar](30) NULL,
	[Country] [nchar](30) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OpInToPrograms]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpInToPrograms](
	[ProgramType] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutPutOfPrograms]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutPutOfPrograms](
	[ProgramType] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentCategoryType]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentCategoryType](
	[Name] [nvarchar](50) NULL,
	[Default] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[paymentMethodType] [nvarchar](50) NULL,
	[referenceId] [nvarchar](50) NULL,
	[referenceType] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPCategoryType]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPCategoryType](
	[RerurnPoliciesID] [int] NOT NULL,
	[Description] [nchar](20) NULL,
	[Default] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RPServiceMethod]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RPServiceMethod](
	[RerurnPoliciesID] [int] NOT NULL,
	[RPReturnsAccepted] [bit] NOT NULL,
	[ReturnPeriodUnit] [nchar](20) NULL,
	[ReturnPeriodValue] [nchar](20) NULL,
	[RefundMethod] [nchar](20) NULL,
	[ReturnShippingCostPayer] [nchar](20) NULL,
	[IOReturnsAccepted] [bit] NOT NULL,
	[IOReturnPeriodUnit] [nchar](20) NULL,
	[IOReturnPeriodValue] [nchar](20) NULL,
	[IOReturnShippingCostPayer] [nchar](20) NULL,
	[ReturnPolicyId] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblAccess_TokenInfo]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAccess_TokenInfo](
	[AccessType] [nchar](20) NULL,
	[AccessToken] [nvarchar](max) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[AccessTokenExpiryDate] [datetime] NULL,
	[RefreshTokenExpiryDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UpdateFulfillmentPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpdateFulfillmentPolicy](
	[Name] [nvarchar](50) NULL,
	[MarketPlaceId] [nvarchar](50) NULL,
	[HandlingTimeValue] [int] NULL,
	[HandlingTimeUnit] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UpdatePaymentPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpdatePaymentPolicy](
	[Name] [nvarchar](50) NULL,
	[MarketPlaceId] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[ImmediatePay] [bit] NULL,
	[PaymentPolicyId] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UpdateReturnPolicy]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpdateReturnPolicy](
	[Name] [nchar](20) NULL,
	[Description] [nchar](20) NULL,
	[MarketplaceId] [nchar](20) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Violations]    Script Date: 11/1/2018 6:49:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Violations](
	[ListViolationDbId] [nchar](30) NULL,
	[ReasonCode] [nchar](100) NULL,
	[Messege] [nchar](100) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[GetFulfillmentPolicy] ([Name], [MarketPlaceId], [HandlingTimeValue], [HandlingTimeUnit]) VALUES (N'Domestic free shipping', N'EBAY_US', 1, N'DAY')
INSERT [dbo].[TblAccess_TokenInfo] ([AccessType], [AccessToken], [RefreshToken], [AccessTokenExpiryDate], [RefreshTokenExpiryDate]) VALUES (N'Auth                ', N'v^1.1#i^1#f^0#p^3#r^0#I^3#t^H4sIAAAAAAAAAOVYa2wUVRTu9oUVWzQpggWTdYqSgLN7Z2dmd2ZgV5c+7Ma+7JYKNU29O3OnnWV2Zp2ZpWxITW0EX4kQMAYVsEGUGIRIkPgmwQdGDBECMYjWkBqJhRhCgkKjMd7ZttttRaAtPzax2aSZc8/j+757zs2dAT2FRYvW16y/XOyYkdvXA3pyHQ5qJigqLFhckpdbVpADMhwcfT0LevJ7835dasKYGheakBnXNRM518RUzRRSRj+RMDRBh6ZiChqMIVOwRCEcrKsVPC4gxA3d0kVdJZyhSj9BA+DzAFqSZVGUZQ5gqzaas1n3Ez6GQpwXijTgAMsgFq+bZgKFNNOCmuUnPIDiSIoiAdVMeQSGE1jgAizbSjhbkGEquoZdXIAIpOAKqVgjA+u1oULTRIaFkxCBULA63BAMVVbVNy91Z+QKjOgQtqCVMMc/VegScrZANYGuXcZMeQvhhCgi0yTcgeEK45MKwVEwU4CfkhrxgGF9jJf3+DjEeyM3Rcpq3YhB69o4bIsikXLKVUCapVjJ6ymK1YhEkWiNPNXjFKFKp/3vkQRUFVlBhp+oWhZcuTxc1UQ4w42Nhr5akZBkM6U41sfSjJfxEAEDRvGv3Uvz3EiZ4VwjIk+oU6FrkmJLZjrrdWsZwpjRRGXoDGWwU4PWYARly8aT6cekFaRa7S0d3sOE1anZu4piWAZn6vH6+o82xFgL3KyWoCSJlWgZ0LyH9/JIukpL2LM+6bYI2DsTbGx021hQBCbJGDRWISuuQhGRIpY3EUOGIgk0K3toTkak5OVlkuFlmYywkpekZIQAQpGImN62/0F3WJahRBIWSnfIxIUURTzJWFFBgbJg6auQ1pyMI2KiZ+rYGWmLNaaf6LSsuOB2d3V1ubpol250uD0AUO4VdbVhsRPFIJH2Va7vTCqpBhERjjIVwcIA/MQa3H+4uNZBBJqqqpuqwjXtzQ0PV9WP9u44ZIGJ1v9gGhb1OGrUVUVMZhdF2pAaoWElw0hVsWFaJE2bZDbQs2d9jKKdw8RJYFxx2R3nEvWYW4f4zLJN7SnUzhtxcptYJNfwCYAzuwwEJV1Tk1MJnkSMoq3GI6QbyakUTAdPIgaKop7QrKmUGwmdRIScUGVFVe1TYioFM8InA1ODatJSRDNdclqNH4zHQ7FYwoIRFYWkbJiAjAGnaY5jp00vy1g1wSgyO2t1ss6e9SRGiI9WsrGpkmREDw0iPIiQHKKRKFHStLjXdShZRp1iKYYBPOAZADzT4laJVmfbvnqBT6ZlLyQBHQEkQ7E8GeERvlH5fBEvpuyhWTgtzhWqgo+K7Ltq1OimhabXqhX4RpxdpOx5HB1HVhJFkuMjPMnIkkRCBl+WPSJ/w5RtQ77v6pfLf71VuMe/1AdyUn9Ur+MA6HXsy3U4gBvcS5WDewrzlufn3VZmKhZy4Yuoy1Q6NPyuaiDXKpSMQ8XILXQ8Nv/dt9szPiP0tYG56Q8JRXnUzIyvCmD+2EoBNWtOMcVRFKAoD8OxoBWUj63mU3fmlza/E61Y9NwWUEzwv98xOHS0pPTPOaA47eRwFOTk9zpytgx+XPjC+dnb2+5it3V2LQ2+dfzw9o19xIWOs7Hgsej2SwcfOHfu4mvfbuj++qy7r+RU/+n2ksp5i9uefn3Dnk0rh87mXPlw6+437tu57uKZRy/vCZbvG9gYKPty7a5Xvlvyx+kX7wbUXvJBtGrw+0MVDVuGqk90bCsZKD41y6D3Hvnx1Okv+mevO/Hewu5b5fd3Oc5/deDN3Wvrt12w9oZ+fur2M0t+Glh4vOVy/6Fbnh3a+nKUnTcw99N1P5Tu++SJmudX+K98tv/vXP8vl745uWN5VArO7H3uaMvngdIZJ4tqX9L/0vbDloc2n+heUPPBqwfb2jYfe7I01nH4mdb9O8oGo87+8iUzNnX/Vv34zvuPfDS8ff8AtIoaDuARAAA=', N'v^1.1#i^1#f^0#p^3#r^0#I^3#t^H4sIAAAAAAAAAOVYa2wUVRTu9oUVWzQpggWTdYqSgLN7Z2dmd2ZgV5c+7Ma+7JYKNU29O3OnnWV2Zp2ZpWxITW0EX4kQMAYVsEGUGIRIkPgmwQdGDBECMYjWkBqJhRhCgkKjMd7ZttttRaAtPzax2aSZc8/j+757zs2dAT2FRYvW16y/XOyYkdvXA3pyHQ5qJigqLFhckpdbVpADMhwcfT0LevJ7835dasKYGheakBnXNRM518RUzRRSRj+RMDRBh6ZiChqMIVOwRCEcrKsVPC4gxA3d0kVdJZyhSj9BA+DzAFqSZVGUZQ5gqzaas1n3Ez6GQpwXijTgAMsgFq+bZgKFNNOCmuUnPIDiSIoiAdVMeQSGE1jgAizbSjhbkGEquoZdXIAIpOAKqVgjA+u1oULTRIaFkxCBULA63BAMVVbVNy91Z+QKjOgQtqCVMMc/VegScrZANYGuXcZMeQvhhCgi0yTcgeEK45MKwVEwU4CfkhrxgGF9jJf3+DjEeyM3Rcpq3YhB69o4bIsikXLKVUCapVjJ6ymK1YhEkWiNPNXjFKFKp/3vkQRUFVlBhp+oWhZcuTxc1UQ4w42Nhr5akZBkM6U41sfSjJfxEAEDRvGv3Uvz3EiZ4VwjIk+oU6FrkmJLZjrrdWsZwpjRRGXoDGWwU4PWYARly8aT6cekFaRa7S0d3sOE1anZu4piWAZn6vH6+o82xFgL3KyWoCSJlWgZ0LyH9/JIukpL2LM+6bYI2DsTbGx021hQBCbJGDRWISuuQhGRIpY3EUOGIgk0K3toTkak5OVlkuFlmYywkpekZIQAQpGImN62/0F3WJahRBIWSnfIxIUURTzJWFFBgbJg6auQ1pyMI2KiZ+rYGWmLNaaf6LSsuOB2d3V1ubpol250uD0AUO4VdbVhsRPFIJH2Va7vTCqpBhERjjIVwcIA/MQa3H+4uNZBBJqqqpuqwjXtzQ0PV9WP9u44ZIGJ1v9gGhb1OGrUVUVMZhdF2pAaoWElw0hVsWFaJE2bZDbQs2d9jKKdw8RJYFxx2R3nEvWYW4f4zLJN7SnUzhtxcptYJNfwCYAzuwwEJV1Tk1MJnkSMoq3GI6QbyakUTAdPIgaKop7QrKmUGwmdRIScUGVFVe1TYioFM8InA1ODatJSRDNdclqNH4zHQ7FYwoIRFYWkbJiAjAGnaY5jp00vy1g1wSgyO2t1ss6e9SRGiI9WsrGpkmREDw0iPIiQHKKRKFHStLjXdShZRp1iKYYBPOAZADzT4laJVmfbvnqBT6ZlLyQBHQEkQ7E8GeERvlH5fBEvpuyhWTgtzhWqgo+K7Ltq1OimhabXqhX4RpxdpOx5HB1HVhJFkuMjPMnIkkRCBl+WPSJ/w5RtQ77v6pfLf71VuMe/1AdyUn9Ur+MA6HXsy3U4gBvcS5WDewrzlufn3VZmKhZy4Yuoy1Q6NPyuaiDXKpSMQ8XILXQ8Nv/dt9szPiP0tYG56Q8JRXnUzIyvCmD+2EoBNWtOMcVRFKAoD8OxoBWUj63mU3fmlza/E61Y9NwWUEzwv98xOHS0pPTPOaA47eRwFOTk9zpytgx+XPjC+dnb2+5it3V2LQ2+dfzw9o19xIWOs7Hgsej2SwcfOHfu4mvfbuj++qy7r+RU/+n2ksp5i9uefn3Dnk0rh87mXPlw6+437tu57uKZRy/vCZbvG9gYKPty7a5Xvlvyx+kX7wbUXvJBtGrw+0MVDVuGqk90bCsZKD41y6D3Hvnx1Okv+mevO/Hewu5b5fd3Oc5/deDN3Wvrt12w9oZ+fur2M0t+Glh4vOVy/6Fbnh3a+nKUnTcw99N1P5Tu++SJmudX+K98tv/vXP8vl745uWN5VArO7H3uaMvngdIZJ4tqX9L/0vbDloc2n+heUPPBqwfb2jYfe7I01nH4mdb9O8oGo87+8iUzNnX/Vv34zvuPfDS8ff8AtIoaDuARAAA=', CAST(0x0000A98D00000000 AS DateTime), CAST(0x0000A98E00000000 AS DateTime))
USE [master]
GO
ALTER DATABASE [Ebay_Api] SET  READ_WRITE 
GO
