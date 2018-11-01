using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaySdkLib.Constants
    {
    static class ApplicationConstants
        {

        public const string TokenUrl = "https://api.ebay.com/identity/v1/";
     
        public const string AppID = "RajeshLo-MyApplic-PRD-4c230b90b-8e3ecd1d";

        public const string AppSecretkey = "PRD-c230b90b5dcc-89b9-4fdd-a4fe-2c9d";
        public const string scope = "https://api.ebay.com/oauth/api_scope https://api.ebay.com/oauth/api_scope/buy.order.readonly https://api.ebay.com/oauth/api_scope/buy.guest.order https://api.ebay.com/oauth/api_scope/sell.marketing.readonly https://api.ebay.com/oauth/api_scope/sell.marketing https://api.ebay.com/oauth/api_scope/sell.inventory.readonly https://api.ebay.com/oauth/api_scope/sell.inventory https://api.ebay.com/oauth/api_scope/sell.account.readonly https://api.ebay.com/oauth/api_scope/sell.account https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly https://api.ebay.com/oauth/api_scope/sell.fulfillment https://api.ebay.com/oauth/api_scope/sell.analytics.readonly https://api.ebay.com/oauth/api_scope/sell.marketplace.insights.readonly https://api.ebay.com/oauth/api_scope/commerce.catalog.readonly";

        public const string CONTENT_TYPE = "application/json";
        public const string BASE_URL = "https://api.ebay.com/";
        public const string CONTENT_LANGUAGE = "en-GB";
        // public const string TOKEN = "v^1.1#i^1#f^0#I^3#p^3#r^0#t^H4sIAAAAAAAAAOVYa2wUVRTu9kVILTWxQVKpbqcoUZjdO4/dnZmwq0ufa+mD3UJokZQ7M3fagdmZzcxs20kMKTVgDAajMQE1JBVNjBJjiZGk8YFBKhDTKCL+gIiifyAhasQHPwx4Z/vaVgTa8mMTN5Ns5tzz+r57zsm9AwaKFz+2u3H3X6WeRflDA2Ag3+OhSsDi4qJVSwryK4ryQJaCZ2hgxUDhYMGlNRZMaikhjqyUoVvI25/UdEvICMNE2tQFA1qqJegwiSzBloREtHmdQPuAkDIN25AMjfDGasMEL4qUDIHEhIAYYhQs1CddththIsSzUOFFBHmaEREN8bplpVFMt2yo22GCBhRHUhQJqHaKEhhWCHC+IMt2Et6NyLRUQ8cqPkBEMtkKGVszK9VbZwotC5k2dkJEYtH6RGs0VlvX0r7Gn+UrMkFDwoZ22pr5VmPIyLsRaml06zBWRltIpCUJWRbhj4xHmOlUiE4mM4/0M0wHZZpHPI1YiuY4lkN3hcp6w0xC+9Z5uBJVJpWMqoB0W7Wd2zGK2RC3IcmeeGvBLmK1XvdvfRpqqqIiM0zUrY12bEjUxQlvoq3NNHpVGckuUooLhAIMG2RpImLCbfjpCjI8NxFm3NcEybPi1Bi6rLqUWd4Ww16LcM5oNjN0FjNYqVVvNaOK7eaTrcdMMsjwne6Wju9h2u7R3V1FSUyDN/N6e/4nC2K6BO5WScgMF6SCiAuF8MNIwZuVhNvrcy2LiLsz0bY2v5sLEqFDJqG5HdkpDUqIlDC96SQyVVlgAgrNcAoi5SCvkCyvKKQYkIMkpSAEEBJFaWrb/gfVYdumKqZtNFUhsxcyEMOEy6igQkWwje1Ib3dSiJitmRk7E2XRb4WJHttOCX5/X1+fr4/xGWa3nwaA8m9qXpeQelASz9VJXfX2yqSaKRAJjxCsL9g4gTDRj+sPB9e7iUi8rj5el2jsam9tqmuZrN0ZmUVmS/8DaUIyUqjN0FTJyS2IjCm3QdN2EkjTsGBBIC0XZE7Ac3t9CqLrw8JOYEr1uRXnk4yk34B4ZrmirkzW3jtR8luYJN/4BMCefSaCsqFrznyM52Cj6r24hQzTmU/AKeM52EBJMtK6PZ9wE6ZzsFDSmqJqmjsl5hMwy3wuaepQc2xVsqZCLqjwo6lULJlM21DUUEzOiQ6YbnCG4bjAguHlGKo43IasnnUG2ey4vY4zxKOVbIvXkqxEM0DkgUhyiEGSTMkLwt7creYYdCpAsSzgAc8CQC8IWy3qzbV9DYKQwihBSAJGBCRLBXhS5BE+UYVCYhBDppkAXBDmGk3FoyL3jhqNhmWjhZVqDT4R5xYotx8n2zEgSxLJ8SJPsoosk5DFh2Va4u8YckZQGLzp4fJftwr/zDt9JC/zowY9H4BBz+F8jwf4wcNUNagqLthQWHBPhaXayIcPoj5L7dbxXdVEvu3ISUHVzC/2bF4+/HZX1leEoS1g2dR3hMUFVEnWRwWwfHqliCq7v5TiKApQFMWwAa4TVE+vFlJLC8sTwqm3hqsHy/QttVZVddVHlY82nAalU0oeT1Fe4aAnL/rDloPV119f9XxP1dFdKx/fs7TylYtjIwPl1+LnqoATuPfCtVOrnUMPjH7ao18pGxvb9VJt/Mjo54FR9HTXyq190pnz1cVfNUg/bnzhyx07z7385Nj5T5xrZolZ9NCx4avGPv8f108saijc1N+1zxypLP+247m9IyeGyiqS1EiiufuJiwdX1K1+qvznk8feePH79YnD1gXv4fe/+5DvP9r6e9+Ry689u6vp7JuXf/lz+ekLpZfO/tTUVd/kdJyJ7diwxnPgnR35V+47dPTrg0t6qyt3/j3c/erWq2M7T3Y8uP/4gVM3fv34t837l2mfXWFudH5T8oV5frT4DFPxbnNjy95HuCXHnfea9lSdeGZMvjq+ff8AgQ48Ot8RAAA=";
        public const string PaymentPolicy_Url = "sell/account/v1/payment_policy/";
        public const string RATETABLE_URL = "sell/account/v1/rate_table/?country_code=";
        public const string INVENTORY_URL = "sell/inventory/v1/";
        public const string RETURNPOLICY_URL = "sell/account/v1/return_policy/";
        public const string INVENTORYLOCATION_URL = "sell/inventory/v1/location/";
        public const string INVENTORYOFFER_URL = "sell/inventory/v1/offer/";
        public const string JURISDICTION_URL = "sell/metadata/v1/country/";
        public const string MARKETPLACE_URL = "sell/metadata/v1/marketplace/";
        public const string ACCEPT_ENCODING = "application/gzip";
        public const string INVENTRYITEMGROUP_URL = "sell/inventory/v1/inventory_item_group/";
        public const string _URLCOMPAIGN = "sell/marketing/v1/ad_campaign/";
        public const string _URLPROMOTION = "sell/marketing/v1/item_promotion";
        public const string PRODCOMPATIBILITY_URL = "sell/inventory/v1/inventory_item/";
        public const string CreateOrReplaceInventory_URL = "sell/inventory/v1/inventory_item/";

        public const string ANALYTICS_URL = "sell/analytics/v1/traffic_report/";

        public const string COMPLIANCE_URL = "sell/compliance/v1/listing_violation_summary";
        public const string SELLER_STANDARDS_URL = "sell/analytics/v1/seller_standards_profile";
        public const string LISTINGVIOLATION_URL = "sell/compliance/v1/listing_violation";
        public const string CATALOG_URL = "commerce/catalog/v1_beta/product";
        public const string PRODUCTMETADATA_URL = "commerce/catalog/v1_beta/get_product_metadata";
        public const string PRODUCTMETADATAFORCATEGORIES_URL = "commerce/catalog/v1_beta/product";
        public const string GETCHANGEREQUEST_URL = "commerce/catalog/v1_beta/change_request";
        public const string SELLER_ANALYTICS_URL = "sell/analytics/v1/seller_standards_profile";

        public const string BULKCREATEADSBYINVENTORY_URL = "sell/marketing/v1/ad_campaign/";
        public const string GETREPORT_URL = "sell/marketing/v1/ad_report/";
        public const string GETREPORTMETADATA_URL = "sell/marketing/v1/ad_report_metadata/";


        public const string ADDREPORTTASK_URL = "sell/marketing/v1/ad_report_task";

        public const string PROMOTIONLIST_URL = "sell/marketing/v1/promotion";
        public const string ITEMPRICE_URL = "sell/marketing/v1/item_price_markdown";
        public const string PROMOTIONREPORT_URL = "sell/marketing/v1/promotion_report";
        public const string PROMOTIONSUMMARYREP_URL = "sell/marketing/v1/promotion_summary_report";
        public const string ORDER_URL = "sell/fulfillment/v1/order/";
        public const string ORDERS_URL = "sell/fulfillment/v1/order";
        public const string PROGRAM_URL  = "sell/account/v1/program";
        public const string FULFILMENT_URL = "sell/account/v1/fulfillment_policy";
        public const string PRIVILAGE_URL = "sell/account/v1/privilege";
        public const string SALESTAX_URL = "sell/account/v1/sales_tax/";
        }
    }
