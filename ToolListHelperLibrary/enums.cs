namespace ToolListHelperLibrary
{
    public enum ListType
    {
        Primary = 1,
        Secondary = 2
    }
    public enum NcFileMode
    {
        Developing,
        Release,
        Archive,
        Retransmission,
        None
    }
    public enum NcFileType
    {
        Sinumeric,
        Fusion,
        ShopTurn,
        Auto
    }
    public enum ToolType
    {
        Item,
        Assembly
    }
    public enum CreatingMode
    {
        New,
        Update
    }
    public enum DictonaryMode
    {
        Global,
        Local
    }
    public enum DatabaseMode
    {
        Test,
        Prod
    }
    public enum ListStatus
    {
        Preparing,
        Ready
    }
}
