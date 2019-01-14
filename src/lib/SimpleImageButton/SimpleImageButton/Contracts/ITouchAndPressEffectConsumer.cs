namespace SimpleImageButton.SimpleImageButton.Contracts
{
    /// <summary>
    /// A consumer of <see cref="EventType"/>s
    /// </summary>
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