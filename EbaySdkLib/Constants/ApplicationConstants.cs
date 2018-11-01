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
       // public const string AppID = "BGUKLogi-SellerTo-PRD-1abd43d69-a5fc6595";
        public const string AppID = "saurabhg-testing-PRD-87f449ff7-4496e93d";

        public const string AppSecretkey = "PRD-7f449ff72b2c-5aeb-4d4a-816d-6044";
        public const string scope = "https://api.ebay.com/oauth/api_scope https://api.ebay.com/oauth/api_scope/buy.order.readonly https://api.ebay.com/oauth/api_scope/buy.guest.order https://api.ebay.com/oauth/api_scope/sell.marketing.readonly https://api.ebay.com/oauth/api_scope/sell.marketing https://api.ebay.com/oauth/api_scope/sell.inventory.readonly https://api.ebay.com/oauth/api_scope/sell.inventory https://api.ebay.com/oauth/api_scope/sell.account.readonly https://api.ebay.com/oauth/api_scope/sell.account https://api.ebay.com/oauth/api_scope/sell.fulfillment.readonly https://api.ebay.com/oauth/api_scope/sell.fulfillment https://api.ebay.com/oauth/api_scope/sell.analytics.readonly https://api.ebay.com/oauth/api_scope/sell.marketplace.insights.readonly https://api.ebay.com/oauth/api_scope/commerce.catalog.readonly";



        public const string CONTENT_TYPE = "application/json";
        public const string BASE_URL = "https://api.ebay.com/";
        public const string CONTENT_LANGUAGE = "en-GB";
        public const string TOKEN = "v^1.1#i^1#I^3#f^0#p^1#r^0#t^H4sIAAAAAAAAAOVYXWwUVRTu9o80LSACBcToOhAV68zOX5fdSbu65UcWoa1uSxCDzZ2ZO+3A7Mxk7h3axQRL05QYLQZRMaDAAyog+iBgAlLFCAlaiT88GA34pCkpNmok4AMa70xL2VYCSynYxH2ZzL3nnvud73xn7tnLthYWPdSxqOPi+MC43J2tbGtuIMAVs0WFBWUT8nLvKshhMwwCO1tnt+a35Z2tQCBl2NKTENmWiWCwJWWYSPIHKynXMSULIB1JJkhBJGFFSsaXLpF4hpVsx8KWYhlUMDG/koJhVoxwUOZAWFBFTiOj5mWfdVYlxUUBB8WoHNYUXmBVgcwj5MKEiTAwcSXFs1yE5liaD9exYYnjJV5k2HB0BRVcBh2kWyYxYVgq5sOV/LVOBtZrQwUIQQcTJ1QsEV+YrIkn5i+orqsIZfiKDfCQxAC7aOjbPEuFwWXAcOG1t0G+tZR0FQUiRIVi/TsMdSrFL4MZAXyfahFGBBFEylWO51QeaqNC5ULLSQF8bRzeiK7Smm8qQRPrOH09Rgkb8iqo4IG3auIiMT/oPZ5wgaFrOnQqqQVV8afitbVUDAHXAXJTI40hwrrZSCerltNQi2hA5MojtMyFRT4Mygf26Xc2wPKwjeZZpqp7nKFgtYWrIAENh1PDZlBDjGrMGieuYQ9Qpl3kMoWisMLLaX8SXdxkemmFKcJD0H+9fgIGV2Ps6LKL4aCH4RM+Q5UUsG1dpYZP+lIcUE8LqqSaMLalUKi5uZlpFhjLaQzxLMuFli9dklSaYApQnq1X6769fv0FtO6HokCyEukSTtsESwuRKgFgNlIxgeNYce4A70NhxYaP/msgI+bQ0IIYrQKJqAIvz5UjQhSwEQ5wo1EgsQGNhjwcUAZpOgWc1RDbBlAgrRCduSno6KoklGu8ENEgrYajGi1GNY2Wy9UwzWkQshDKshKN/I/qJFulJxXLhrWWoSvp0dH7qGndUWuBg9NVbpq8J6FhkEe20r9qqMgL9ZYG6dX6DQfq+UDECbB1xhM4o1ipkAXIl80bavBRB7MxCslumml0iTIJbJWcLVkv0olEGFInavZL+quQBJD9EtK4qK6CR7SRX+4MYVJvbMLohvZsGQEpiMiNMaxGnVS5ghjbVa2bkl7cthOplIuBbMDEKB0s/82hctXwdNJ1jamYSE77k6ur/e0S42eYQWsUxoHIch3SKTI1XvtQZ62GJvkaY8cyDOgs47JkYrCHv2qyx1iOb+zcGpkIRrFnGkPSVgydKKhhrEV2OxKqAzy2gubKRbZcEAVRvKm45vkprUtn3wzkr//q9kS4yEIYqregwQ8NvW2I5fg/ri3QxbYFDuUGAuxclubK2DmFefX5eSUUIi0Bg4CpylYLowONIQevSf5MO5BZDdM20J3cwsDTM3sfuZRxz7FzJTt98KajKI8rzrj2YO++MlPATZw2notwLB9mwxzPiyvYWVdm87nS/CnUpgdPrz+04YO99We33jfze6vt2HcJdvygUSBQkJPfFsh587WT01MXtp/645lp5zoKPsSv9F768ULFkb/yt+dGQ4d3HTv5atWpwyVvPP5O98mafSd+RQv5nyat39bw99HmL78u6ogUf2507tvRda70yOyP2tuPb37p/G8/2KVbOtfsOSDYvSvNje+DknvSn/JfbLFLXyj7ZVH3+fqp++q2zfh9r3HwtA4mzOmcKex6/ZN7t69dvPuxvoo7DrZ8NilQ22NUp0+Mm7Ln9B1VBX37Q+8t3nDA7lnws/Pi0fpNW5/vKp7cW9L3aE9Z76GNG+XSiWujq2Zf3Fo2a8edQfb+Od1/bn742arJ2gOdB3re2j/hzFTtzO6Gvg3iusJv4jM+7kp/+1z7u2/nqi+v6z3eXruruz+N/wCSRR3UgRIAAA==v^1.1#i^1#I^3#r^0#f^0#p^1#t^H4sIAAAAAAAAAOVYb2wURRTv9a8FW0KCINXIsUpMwd3b3bvt3a3cyZXy5wzXFq9AoRAytzt7XbnbXXdm6Z2gKSVAQghBDYZEPzQGEjSKkQ8qJmoiBmpCFAgkBAIKGgSiiUEQTPjg7N5RrpXAUQ5s4n7ZzMx7b977vd/beTtsb3Xt9I3zN16rc9WU9/eyveUuFzeWra2umlFfUd5QVcYWCLj6e5/preyruDATgXTKEF+CyNA1BN2ZdEpDojMZoixTE3WAVCRqIA2RiCUxHoktEHmGFQ1Tx7qkpyh3tCVEyX5BDsgc74O80iT4WDKr3bTZoYco4Gf9XFDhfN6g1wdlL1lHyIJRDWGg4RDFs1yA5ljay3VwrMgLosAzgiAso9yLoYlUXSMiDEuFHXdFR9cs8PXOrgKEoImJESocjcyNt0WiLXNaO2Z6CmyF8zjEMcAWGjqarcvQvRikLHjnbZAjLcYtSYIIUZ5wboehRsXITWdG4L4Dtc8HAcsHmwJCgvfLUCgJlHN1Mw3wnf2wZ1SZVhxREWpYxdm7IUrQSLwMJZwftRIT0Ra3/VpogZSqqNAMUXOaI0sj7e1UGAHLBInuJI0hwqqWpOPNnTRUAgrwcUKATnBNPr4JCPl9csbyKA/baLauyaqNGXK36rgZEqfhcGi4AmiIUJvWZkYUbDtUKMffhJAPLrNzmkuihbs1O60wTXBwO8O7J2BQG2NTTVgYDloYvuAgRKrGMFSZGr7oUDHPngwKUd0YG6LH09PTw/R4Gd1MeniW5TydsQVxqRumAWXL2rXuyKt3V6BVJxQJEk2kijhrEF8yhKrEAS1Jhb0cx/r8edyHuhUePvuviYKYPUMLolQFokDFz8KA4IdBf9AXCJaiQMJ5jnpsP2ACZOk0MFdBbKSABGmJ8MxKQ1OVRa+g8N6AAmm5KajQvqCi0AlBbqI5BUIWwkRCCgb+R3VSLNPjkm7Adj2lStnS8L1kXDfldmDibLOVJeM4TKXIq1jq3zZUZIf6QIO0a/2eA7VtIGIEGCpjE5yR9LRHB+TLZk+tdLx2FyPkSVhZJmkRZhK3ZXK2FK2kEoowpE7k4lVyVUgCKF6FNC6yJeERbeSUO0OQVJPdGN3TnpkRgIII3ZiUnlRJlUuIMSxZvy/qRQwjmk5bGCRSMFqig+W/OVRuG55Kuq5RFRPJaS65qpxrlxgnwwxaLTEmRLplkk6RabPbhw59FdTI1xibeioFzcVckUgM9vC3TfYoy/G9nVsjI0EJe6ZRRG0ppRIGrRxtkT2MhKoAj66gOfJ/GwxwgsDfV1yznZR2ZItvBirX/fBwIpyvIwzlB9Dge4beNoTLnIfrc33J9rn2lbtcrJ+luRlsY3XFosqKRylEWgIGAU1O6BlGBQpDDl6N/EybkFkFswZQzfJqV9cTl164UXDP0b+CfXzwpqO2ghtbcO3BPnlrpYobN6mOC3CsXZ88Secy9ulbq5XcxMoJR989eXBP2fq1xtWf0dy+2injawYa2bpBIZerqqyyz1W2Y8HVzjPXfG/04suXttdlOjunLJ96qP/g/k1vf7Sz5cSr1/cL335z6cLeeZurViTXH9/QuqjxQM3ki7EpwtHqCctPVC88fOXDc+PeeuSxE9POTjtVs30gvaXtT69+bM3kBg9Tf2gHvztx+uO+N3c+NYl2P9ebmf/TmT1T9806ufudDcf7z5+eF/otdqx+hadt8xf1u8zxNeu7aGVg7Gt4YO+NX2tif69eVN56/bsl22L7zkprzoNG6sWvv2+Zt/dIWt86sf/AmGeX1G75sYH97PDrwqYxsYodSz+f1TVj2l9/dDHnN6cz11+5WH/k91+mNxz+6tSnu3aee/89cKV9zKFtq6vo3RMv13/wvHdd48JP1ubS+A+4x5XvgRIAAA==";
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
