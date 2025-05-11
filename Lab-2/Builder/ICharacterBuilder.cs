namespace Builder
{
    interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetBody(string bodyType);
        ICharacterBuilder SetHairColor(string color);
        ICharacterBuilder SetEyeColor(string color);
        ICharacterBuilder AddItem(string item);
        ICharacterBuilder AddAction(string action);
        GameCharacter Build();
    }
}
