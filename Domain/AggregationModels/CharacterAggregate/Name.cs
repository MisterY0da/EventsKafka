namespace Domain.AggregationModels.CharacterAggregate
{
    public class Name
    {
        public string Value { get; set; }

        public Name(string value) 
        {
            Value = value;
        }
    }
}
