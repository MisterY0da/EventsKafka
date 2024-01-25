namespace Domain.AggregationModels.CharacterAggregate
{
    public class CharacterClass
    {
        public string Value { get; set; }

        public CharacterClass(string value) 
        {
            Value = value;
        }
    }
}
