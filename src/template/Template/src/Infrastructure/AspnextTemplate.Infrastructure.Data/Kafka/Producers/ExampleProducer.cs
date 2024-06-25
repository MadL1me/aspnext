using AspnextTemplate.Domain.Producers;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspnextTemplate.Infrastructure.Data.Kafka.Producers;

public class ExampleProducer : IExampleProducer
{
    private readonly IConfiguration _configuration;
    private readonly IProducer<string, string> _producer;

    public ExampleProducer(IConfiguration configuration)
    {
        _configuration = configuration;

        var producerconfig = new ProducerConfig
        {
            BootstrapServers = _configuration["Kafka:BootstrapServers"]
        };

        _producer = new ProducerBuilder<string, string>(producerconfig).Build();
    }

    public Task Finish(CancellationToken cancellationToken)
    {
        // some producing logic
        return Task.CompletedTask;
    }
}
