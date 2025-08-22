
public class PackageScans
{
    public long SEQ_NO { get; set; }
    public int VERSION_NO { get; set; }
    public string? LOAD_ID { get; set; }
    public string CONTAINER_ID { get; set; } = null!;
    public string? CARRIER_EORI_NUMBER { get; set; }
    public int GOODS_ITEM_NUMBER { get; set; }
    public string PRODUCT_CODE { get; set; } = null!;
    public string? COUNTRY_CODE { get; set; }
    public string COUNTRY_OF_ORIGIN_CODE { get; set; } = null!;
    public string COMMODITY_CODE { get; set; } = null!;
    public string ITEM { get; set; } = null!;
    public long ITEM_NUMBER { get; set; }
    public long? CUSTOMER_ID { get; set; }
    public string? CUSTOMER_REF { get; set; }
    public string? EXPORTER_NAME { get; set; }
    public string? EXPORTER_ADDRESS1 { get; set; }
    public string? EXPORTER_ADDRESS2 { get; set; }
    public string? EXPORTER_ADDRESS3 { get; set; }
    public string? EXPORTER_ADDRESS4 { get; set; }
    public string? EXPORTER_CITY { get; set; }
    public string? EXPORTER_POSTCODE { get; set; }
    public string? EXPORTER_COUNTRY { get; set; }
    public string? IMPORTER_NAME { get; set; }
    public string? IMPORTER_ADDRESS1 { get; set; }
    public string? IMPORTER_ADDRESS2 { get; set; }
    public string? IMPORTER_ADDRESS3 { get; set; }
    public string? IMPORTER_ADDRESS4 { get; set; }
    public string? IMPORTER_CITY { get; set; }
    public string? IMPORTER_POSTCODE { get; set; }
    public string? IMPORTER_COUNTRY { get; set; }
    public string? POSTAGE_CURRENCY { get; set; }
    public decimal? POSTAGE_AMOUNT { get; set; }
    public string? TYPE_OF_GOODS { get; set; }
    public string? TYPE_OF_GOODS_DESC { get; set; }
    public decimal? ADDITIONAL_FEES_AMOUNT { get; set; }
    public string? ADDITIONAL_FEES_CURRENCY { get; set; }
    public string DECLARED_VALUE_CURRENCY { get; set; } = null!;
    public decimal? DECLARED_VALUE { get; set; }
    public string? EUDR_DDS_NUMBER { get; set; }
    public string? EUDR_EXEMPTION_CODE { get; set; }
    public string DESCRIPTION_OF_GOODS { get; set; } = null!;
    public int NUMBER_OF_PACKAGES { get; set; }
    public decimal? NET_MASS { get; set; }
    public DateTime ESCAN_DATETIME { get; set; }
    public DateTime TIMESTAMP { get; set; }
    public string? SKU { get; set; }
    public string? CONT_OR_SITE_CODE { get; set; }
    public string? CONT_DSTN_SITE_CODE { get; set; }
    public int? JUST_PARCELS_RNUM { get; set; }
    public int? JUST_CONTENTS_DENSE_RANK { get; set; }
}

