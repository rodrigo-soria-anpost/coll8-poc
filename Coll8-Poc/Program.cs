using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var fileText = File.ReadAllText("Template/Coll8_Template.txt");
        var templateHeader = fileText.Split(Environment.NewLine)[0];
        var templateContent = fileText.Split(Environment.NewLine)[1];

        var dtos = BuildFakePackageScansDto();
        var txtContent = MapToTxt(templateHeader, templateContent, dtos);
        var fileName = $"SH-DEVTEST01_{DateTime.UtcNow:yyyyMMddHHmmss}.TXT";

        File.WriteAllText(fileName, txtContent);
    }

    static string MapToTxt(string header, string lineTemplate, List<PackageScansDto> dtos)
    {
        StringBuilder sb = new();
        sb.AppendLine(header);

        foreach (var dto in dtos)
        {
            var newLine = lineTemplate;

            var trackingNumber = $"{dto.ProductCode}{dto.Item.Number.ToString().PadLeft(9, '0')}{dto.CountryCode}";
            var itemPrice = dto.DeclaredValue.Amount / dto.NumberOfPackages;
            var additionalCode = string.Concat("[{Code=dds&Value=", dto.Eudr!.DdsNumber, "};{Code=", dto.Eudr!.ExemptionCode + "&Value=NAI}]");
            var utcNow = DateTime.UtcNow.ToString("yyyy-MM-dd");

            var totalTotalInvoiceAmount = dtos
                .Where(x => x.ProductCode == dto.ProductCode && x.Item.Number == dto.Item.Number && x.CountryCode == dto.CountryCode)
                .Sum(x => x.DeclaredValue.Amount);

            var deliveryAgent = string.Empty;
            if (dto.CountryCode == "GB") deliveryAgent = "Royal Mail";
            else if (dto.CountryCode == "US") deliveryAgent = "USPS";

            // Shipment Details
            newLine = newLine.Replace("{AccountCode}", "SH-DEVTEST01"); // Non-Prod (SH-DEVTEST01), Prod (ANP0002)
            newLine = newLine.Replace("{ExporterShipperAccountCode}", "");
            newLine = newLine.Replace("{ShipmentTrackingNumber}", dto.ContainerId);
            newLine = newLine.Replace("{ShippingDate}", utcNow);
            newLine = newLine.Replace("{DeliveryAgent}", deliveryAgent); 

            // Exporter/Consignor Name
            newLine = newLine.Replace("{ExporterEORINumber}", "IE4802830A"); // Non-Prod (IE4802830A), Prod (IE4736920J)
            newLine = newLine.Replace("{ExporterCompanyName}", dto.Exporter!.Name);
            newLine = newLine.Replace("{ExporterAddressLine1}", dto.Exporter.Address1);
            newLine = newLine.Replace("{ExporterAddressLine2}", dto.Exporter.Address2);
            newLine = newLine.Replace("{ExporterAddressLine3}", dto.Exporter.Address3);
            newLine = newLine.Replace("{ExporterCity}", dto.Exporter.City);
            newLine = newLine.Replace("{ExporterState}", "");
            newLine = newLine.Replace("{ExporterPostCode}", dto.Exporter.Postcode);
            newLine = newLine.Replace("{ExporterCountryCode}", dto.Exporter.Country);
            newLine = newLine.Replace("{ExporterContactName}", "");
            newLine = newLine.Replace("{ExporterPhoneNumber}", "");
            newLine = newLine.Replace("{ExporterEmail}", "");

            // Importer / Consignee 
            newLine = newLine.Replace("{ImporterEORINumber}", "");
            newLine = newLine.Replace("{ImporterCompanyName}", dto.Importer!.Name);
            newLine = newLine.Replace("{ImporterAddressLine1}", dto.Importer.Address1);
            newLine = newLine.Replace("{ImporterAddressLine2}", dto.Importer.Address2);
            newLine = newLine.Replace("{ImporterAddressLine3}", dto.Importer.Address3);
            newLine = newLine.Replace("{ImporterCity}", dto.Importer.City);
            newLine = newLine.Replace("{ImporterState}", "");
            newLine = newLine.Replace("{ImporterPostCode}", "");
            newLine = newLine.Replace("{ImporterCountryCode}", dto.Importer.Country);
            newLine = newLine.Replace("{ImporterContactName}", dto.Importer.Name);
            newLine = newLine.Replace("{ImporterPhoneNumber}", "");
            newLine = newLine.Replace("{ImporterEmail}", "");

            // Import Package
            newLine = newLine.Replace("{PackageTrackingNumber}", trackingNumber);
            newLine = newLine.Replace("{PalletTrackingNumber}", "");
            newLine = newLine.Replace("{UOMWeight}", "");
            newLine = newLine.Replace("{GrossMassWeight}", "");
            newLine = newLine.Replace("{NetMassWeight}", "");

            // Import Package Items
            newLine = newLine.Replace("{ItemPrice}", itemPrice.ToString());
            newLine = newLine.Replace("{ItemQtyUOM}", "KG"); // Always KG
            newLine = newLine.Replace("{ItemQuantity}", dto.NumberOfPackages.ToString());
            newLine = newLine.Replace("{ItemInvoiceAmount}", dto.DeclaredValue.Amount.ToString());
            newLine = newLine.Replace("{CommodityCode}", dto.CommodityCode);
            newLine = newLine.Replace("{ItemCountryOfOrigin}", dto.CountryOfOriginCode);
            newLine = newLine.Replace("{ItemGoodsDescription}", dto.TypeOfGoods!.Description);
            newLine = newLine.Replace("{ItemPackagingType}", "BOX"); // Always BOX
            newLine = newLine.Replace("{SKUCode}", dto.Sku);
            newLine = newLine.Replace("{CommodityNational}", "");
            newLine = newLine.Replace("{ItemUOMWeight}", "");
            newLine = newLine.Replace("{ItemGrossWeight}", dto.NetMass.ToString());
            newLine = newLine.Replace("{ItemNetWeight}", dto.NetMass.ToString());
            newLine = newLine.Replace("{MeursingCode}", "");
            newLine = newLine.Replace("{AdditionalCode}", additionalCode);
            newLine = newLine.Replace("{CPC}", "");

            // Invoice
            newLine = newLine.Replace("{InvoiceNumber}", dto.DeclaredValue.Amount.ToString()); // ?? SUM(DeclaredValue) for the Tracking Number
            newLine = newLine.Replace("{InvoiceCurrencyCode}", "EUR"); // Always EUR
            newLine = newLine.Replace("{ShippingCosts}", "");
            newLine = newLine.Replace("{ShippingInsuranceCost}", "");
            newLine = newLine.Replace("{OtherCharges}", "");
            newLine = newLine.Replace("{TotalInvoiceAmount}", totalTotalInvoiceAmount.GetValueOrDefault().ToString());
            newLine = newLine.Replace("{InvoiceDate}", utcNow);
            newLine = newLine.Replace("{IOSS}", "");
            newLine = newLine.Replace("{TANAccountNumber}", "");
            newLine = newLine.Replace("{ReasonForExport}", "");
            newLine = newLine.Replace("{DeliveryTerms}", "CIF"); // Always CIF

            sb.AppendLine(newLine);
        }

        return sb.ToString();
    }

    static List<PackageScansDto> BuildFakePackageScansDto()
    {
        List<PackageScansDto> packageScansDtos =
        [
            new()
            {
                ContainerId = "XX-092963080",
                CountryCode = "GB",
                Exporter = new ExporterInfo()
                {
                    Name = "Exporter Name",
                    Address1 = "Exporter Address 1",
                    Address2 = "Exporter Address 2",
                    Address3 = "Exporter Address 3",
                    City = "Dublin",
                    Postcode = "D01F5P2",
                    Country = "IE"
                },
                Importer = new ImporterInfo()
                {
                    Name = "Importer Name",
                    Address1 = "Importer Address 1",
                    Address2 = "Importer Address 2",
                    Address3 = "Importer Address 3",
                    City = "London",
                    Country = "GB"
                },
                ProductCode = "XX",
                Item = new ItemInfo() { Name = "", Number = 1 },
                DeclaredValue = new DeclaredValueInfo() { Currency = "EUR", Amount = 10 },
                NumberOfPackages = 1,
                CommodityCode = "9505108000",
                CountryOfOriginCode = "GB",
                TypeOfGoods = new TypeOfGoodsInfo() { Description = "Stationery" },
                Sku = "SKU123456789",
                NetMass = 2.5m,
                Eudr = new EudrInfo()
                {
                    DdsNumber = "233455",
                    ExemptionCode = "NAI"
                },
                DescriptionOfGoods = "Sample goods",
            },
            new()
            {
                ContainerId = "XX-092963099",
                CountryCode = "GB",
                Exporter = new ExporterInfo()
                {
                    Name = "Exporter Name",
                    Address1 = "Exporter Address 1",
                    Address2 = "Exporter Address 2",
                    Address3 = "Exporter Address 3",
                    City = "Dublin",
                    Postcode = "D01F5A1",
                    Country = "IE"
                },
                Importer = new ImporterInfo()
                {
                    Name = "Importer Name",
                    Address1 = "Importer Address 1",
                    Address2 = "Importer Address 2",
                    Address3 = "Importer Address 3",
                    City = "London",
                    Country = "GB"
                },
                ProductCode = "XX",
                Item = new ItemInfo() { Name = "", Number = 2 },
                DeclaredValue = new DeclaredValueInfo() { Currency = "EUR", Amount = 5 },
                NumberOfPackages = 1,
                CommodityCode = "9505108001",
                CountryOfOriginCode = "GB",
                TypeOfGoods = new TypeOfGoodsInfo() { Description = "Christmas Decorations" },
                Sku = "SKU123456700",
                NetMass = 5m,
                Eudr = new EudrInfo()
                {
                    DdsNumber = "233455",
                    ExemptionCode = "NAI"
                },
                DescriptionOfGoods = "Sample goods",
            },
        ];

        return packageScansDtos;
    }
}
