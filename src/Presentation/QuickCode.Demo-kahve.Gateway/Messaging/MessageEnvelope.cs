namespace QuickCode.Demo-kahve.Gateway.Messaging;

public record MessageEnvelope<T>(T Message, string CorrelationId) where T : IMessage;
