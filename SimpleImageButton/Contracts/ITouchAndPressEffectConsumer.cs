namespace SimpleImageButton.Contracts
{
    public interface ITouchAndPressEffectConsumer
    {
        void ConsumeEvent(EventType gestureType);
    }

    public enum EventType
    {
        Pressing,
        Released,
        Cancelled
    }
}