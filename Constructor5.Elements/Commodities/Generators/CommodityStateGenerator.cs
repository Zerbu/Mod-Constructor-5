namespace Constructor5.Elements.Commodities.Generators
{
    public abstract class CommodityStateGenerator
    {
        public string Label { get; set; }

        protected internal abstract void OnExport(CommodityExportContext context);
    }
}