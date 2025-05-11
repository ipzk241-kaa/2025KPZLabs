namespace Builder
{
    class HeroBuilder : ICharacterBuilder
    {
        private GameCharacter character = new();

        public ICharacterBuilder SetName(string name) { character.Name = name; return this; }
        public ICharacterBuilder SetBody(string bodyType) { character.BodyType = bodyType; return this; }
        public ICharacterBuilder SetHairColor(string color) { character.HairColor = color; return this; }
        public ICharacterBuilder SetEyeColor(string color) { character.EyeColor = color; return this; }
        public ICharacterBuilder AddItem(string item) { character.Inventory.Add(item); return this; }
        public ICharacterBuilder AddAction(string action) { character.Actions.Add("Good: " + action); return this; }
        public GameCharacter Build() => character;
    }
}
