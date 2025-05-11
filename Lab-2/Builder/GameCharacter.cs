namespace Builder
{
    class GameCharacter
    {
        public string Name, BodyType, HairColor, EyeColor;
        public List<string> Inventory = new();
        public List<string> Actions = new();

        public void Show()
        {
            Console.WriteLine($"Ім'я: {Name}, Будова тіла: {BodyType}, Волосся: {HairColor}, Очі: {EyeColor}");
            Console.WriteLine($"Інвентар: {string.Join(", ", Inventory)}");
            Console.WriteLine($"Дії: {string.Join("; ", Actions)}");
        }
    }
}
