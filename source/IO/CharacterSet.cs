namespace MyClassicGame
{
    enum CharacterSet : int
    {
        UNICODE = 1200, // UTF-16
        UNICODE_FFFE = 1201,
        UTF32 = 12000,
        UTF32_BE = 12001,
        US_ASCII = 20127,
        LATIN_1 = 28591, // 서유럽어, iso-8859-1
        UTF7 = 65000,
        UTF8 = 65001
    }
}