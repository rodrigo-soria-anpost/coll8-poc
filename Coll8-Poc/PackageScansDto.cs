public class PackageScansDto
{
    public long SeqNo { get; set; }                                 // [SEQ_NO] bigint NOT NULL
    public int VersionNo { get; set; }                              // [VERSION_NO] int NOT NULL
    public string? LoadId { get; set; }                             // [LOAD_ID] nvarchar(20) NULL
    public required string ContainerId { get; set; }                // [CONTAINER_ID] nvarchar(10) NOT NULL
    public required string ContainerTripLabel { get; set; }         // [CONTAINER_TRIP_LABEL] nvarchar(10) NOT NULL
    public string? CarrierEoriNumber { get; set; }                  // [CARRIER_EORI_NUMBER] nvarchar(20) NULL
    public int GoodsItemNumber { get; set; }                        // [GOODS_ITEM_NUMBER] int NOT NULL
    public required string ProductCode { get; set; }                // [PRODUCT_CODE] nvarchar(2) NOT NULL
    public string? CountryCode { get; set; }                        // [COUNTRY_CODE] nvarchar(2) NULL
    public string? VatRateCode { get; set; }                        // [VAT_RATE_CODE] nvarchar(4) NULL
    public required string CountryOfOriginCode { get; set; }        // [COUNTRY_OF_ORIGIN_CODE] nvarchar(2) NOT NULL
    public required string CommodityCode { get; set; }              // [COMMODITY_CODE] nvarchar(10) NOT NULL
    public required string DescriptionOfGoods { get; set; }         // [DESCRIPTION_OF_GOODS] nvarchar(256) NOT NULL
    public int NumberOfPackages { get; set; }                       // [NUMBER_OF_PACKAGES] int NOT NULL
    public decimal? NetMass { get; set; }                           // [NET_MASS] NUMBER NULL
    public string? BusinessProcessingPriority { get; set; }         // [BUSINESS_PROCESSING_PRIORITY] nvarchar(20) NULL
    public DateTime EscanDate { get; set; }                         // [ESCAN_DATE] datetime NOT NULL
    public DateTime Timestamp { get; set; }                         // [TIMESTAMP] datetime NOT NULL
    public string? Sku { get; set; }                                // [SKU] nvarchar(15) NULL
    public string? ContOrSiteCode { get; set; }                     // [CONT_OR_SITE_CODE] nvarchar(10) NULL
    public string? ContDstnSiteCode { get; set; }                   // [CONT_DSTN_SITE_CODE] nvarchar(10) NULL
    public int JustParcelsRnum { get; set; }                        // [JUST_PARCELS_RNUM] number NULL
    public int JustContentsDenseRank { get; set; }                  // [JUST_CONTENTS_DENSE_RANK] number NULL
    public required ItemInfo Item { get; set; }                     // ITEM / ITEM_NUMBER
    public CustomerInfo? Customer { get; set; }                     // CUSTOMER_*
    public ExporterInfo? Exporter { get; set; }                     // EXPORTER_*
    public ImporterInfo? Importer { get; set; }                     // IMPORTER_*
    public PostageInfo? Postage { get; set; }                       // POSTAGE_*
    public TypeOfGoodsInfo? TypeOfGoods { get; set; }               // TYPE_OF_GOODS_*
    public AdditionalFeesInfo? AdditionalFees { get; set; }         // ADDITIONAL_FEES_*
    public required DeclaredValueInfo DeclaredValue { get; set; }   // DECLARED_VALUE_*
    public EudrInfo? Eudr { get; set; }                             // EUDR_*
}

public class ItemInfo
{
    public required string Name { get; set; }                       // [ITEM] nvarchar(90) NOT NULL
    public long Number { get; set; }                                // [ITEM_NUMBER] bigint NOT NULL
}

public class CustomerInfo
{
    public long? Id { get; set; }                                   // [CUSTOMER_ID] bigint NULL
    public string? Ref { get; set; }                                // [CUSTOMER_REF] nvarchar(90) NULL
}

public class ExporterInfo
{
    public string? Name { get; set; }                               // [EXPORTER_NAME]
    public string? Address1 { get; set; }                           // [EXPORTER_ADDRESS1]
    public string? Address2 { get; set; }                           // [EXPORTER_ADDRESS2]
    public string? Address3 { get; set; }                           // [EXPORTER_ADDRESS3]
    public string? Address4 { get; set; }                           // [EXPORTER_ADDRESS4]
    public string? City { get; set; }                               // [EXPORTER_CITY]
    public string? Postcode { get; set; }                           // [EXPORTER_POSTCODE]
    public string? Country { get; set; }                            // [EXPORTER_COUNTRY]
}

public class ImporterInfo
{
    public string? Name { get; set; }                               // [IMPORTER_NAME]
    public string? Address1 { get; set; }                           // [IMPORTER_ADDRESS1]
    public string? Address2 { get; set; }                           // [IMPORTER_ADDRESS2]
    public string? Address3 { get; set; }                           // [IMPORTER_ADDRESS3]
    public string? Address4 { get; set; }                           // [IMPORTER_ADDRESS4]
    public string? City { get; set; }                               // [IMPORTER_CITY]
    public string? Postcode { get; set; }                           // [IMPORTER_POSTCODE]
    public string? Country { get; set; }                            // [IMPORTER_COUNTRY]
}

public class PostageInfo
{
    public string? Currency { get; set; }                           // [POSTAGE_CURRENCY]
    public decimal? Amount { get; set; }                            // [POSTAGE_AMOUNT]
}

public class TypeOfGoodsInfo
{
    public string? Code { get; set; }                               // [TYPE_OF_GOODS]
    public string? Description { get; set; }                        // [TYPE_OF_GOODS_DESC]
}

public class AdditionalFeesInfo
{
    public decimal? Amount { get; set; }                            // [ADDITIONAL_FEES_AMOUNT]
    public string? Currency { get; set; }                           // [ADDITIONAL_FEES_CURRENCY]
}

public class DeclaredValueInfo
{
    public required string Currency { get; set; }                   // [DECLARED_VALUE_CURRENCY] NOT NULL
    public decimal? Amount { get; set; }                            // [DECLARED_VALUE]
}

public class EudrInfo
{
    public string? DdsNumber { get; set; }                          // [EUDR_DDS_NUMBER]
    public string? ExemptionCode { get; set; }                      // [EUDR_EXEMPTION_CODE]
}
