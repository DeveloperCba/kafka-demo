using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace Core.Kafka;

public class AdminClient : IAdminClient
{

    private readonly IAdminClient _adminClientBuilder;

    public AdminClient(IAdminClient adminClientBuilder)
    {
        _adminClientBuilder = adminClientBuilder;
    }

    public int AddBrokers(string brokers)
    {
        return _adminClientBuilder.AddBrokers(brokers);
    }

    public void SetSaslCredentials(string username, string password)
    {
        _adminClientBuilder.SetSaslCredentials(username, password);
    }

    public Handle Handle { get; }
    public string Name { get; }
    public List<GroupInfo> ListGroups(TimeSpan timeout)
    {
        return _adminClientBuilder.ListGroups(timeout);
    }

    public GroupInfo ListGroup(string group, TimeSpan timeout)
    {
        return _adminClientBuilder.ListGroup(group, timeout);
    }

    public Metadata GetMetadata(string topic, TimeSpan timeout)
    {
        return _adminClientBuilder.GetMetadata(topic, timeout);
    }

    public Metadata GetMetadata(TimeSpan timeout)
    {
        return _adminClientBuilder.GetMetadata(timeout);
    }

    public async Task CreatePartitionsAsync(IEnumerable<PartitionsSpecification> partitionsSpecifications, CreatePartitionsOptions options = null)
    {
        if (options == null)
            await _adminClientBuilder.CreatePartitionsAsync(partitionsSpecifications);
        else
            await _adminClientBuilder.CreatePartitionsAsync(partitionsSpecifications, options);
    }

    public async Task DeleteGroupsAsync(IList<string> groups, DeleteGroupsOptions options = null)
    {
        if (options == null)
            await _adminClientBuilder.DeleteGroupsAsync(groups);
        else
            await _adminClientBuilder.DeleteGroupsAsync(groups, options);
    }

    public async Task DeleteTopicsAsync(IEnumerable<string> topics, DeleteTopicsOptions options = null)
    {
        if (options == null)
            await _adminClientBuilder.DeleteTopicsAsync(topics);
        else
            await _adminClientBuilder.DeleteTopicsAsync(topics, options);
    }

    public async Task CreateTopicsAsync(IEnumerable<TopicSpecification> topics, CreateTopicsOptions options = null)
    {
        if (options == null)
            await _adminClientBuilder.CreateTopicsAsync(topics);
        else
            await _adminClientBuilder.CreateTopicsAsync(topics, options);
    }

    public async Task AlterConfigsAsync(Dictionary<ConfigResource, List<ConfigEntry>> configs, AlterConfigsOptions options = null)
    {
        if (options == null)
            await _adminClientBuilder.AlterConfigsAsync(configs);
        else
            await _adminClientBuilder.AlterConfigsAsync(configs, options);
    }

    public async Task<List<IncrementalAlterConfigsResult>> IncrementalAlterConfigsAsync(Dictionary<ConfigResource, List<ConfigEntry>> configs, IncrementalAlterConfigsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.IncrementalAlterConfigsAsync(configs);

        return await _adminClientBuilder.IncrementalAlterConfigsAsync(configs, options);
    }

    public async Task<List<DescribeConfigsResult>> DescribeConfigsAsync(IEnumerable<ConfigResource> resources, DescribeConfigsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.DescribeConfigsAsync(resources);

        return await _adminClientBuilder.DescribeConfigsAsync(resources, options);
    }

    public async Task<List<DeleteRecordsResult>> DeleteRecordsAsync(IEnumerable<TopicPartitionOffset> topicPartitionOffsets, DeleteRecordsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.DeleteRecordsAsync(topicPartitionOffsets);

        return await _adminClientBuilder.DeleteRecordsAsync(topicPartitionOffsets, options);
    }

    public async Task CreateAclsAsync(IEnumerable<AclBinding> aclBindings, CreateAclsOptions options = null)
    {
        if (options == null)
            await _adminClientBuilder.CreateAclsAsync(aclBindings);
        else
            await _adminClientBuilder.CreateAclsAsync(aclBindings, options);
    }

    public async Task<DescribeAclsResult> DescribeAclsAsync(AclBindingFilter aclBindingFilter, DescribeAclsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.DescribeAclsAsync(aclBindingFilter);

        return await _adminClientBuilder.DescribeAclsAsync(aclBindingFilter, options);
    }

    public async Task<List<DeleteAclsResult>> DeleteAclsAsync(IEnumerable<AclBindingFilter> aclBindingFilters, DeleteAclsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.DeleteAclsAsync(aclBindingFilters);

        return await _adminClientBuilder.DeleteAclsAsync(aclBindingFilters, options);
    }

    public async Task<DeleteConsumerGroupOffsetsResult> DeleteConsumerGroupOffsetsAsync(string group, IEnumerable<TopicPartition> partitions,
        DeleteConsumerGroupOffsetsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.DeleteConsumerGroupOffsetsAsync(group, partitions);

        return await _adminClientBuilder.DeleteConsumerGroupOffsetsAsync(group, partitions,options);
    }

    public async Task<List<AlterConsumerGroupOffsetsResult>> AlterConsumerGroupOffsetsAsync(IEnumerable<ConsumerGroupTopicPartitionOffsets> groupPartitions, AlterConsumerGroupOffsetsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.AlterConsumerGroupOffsetsAsync(groupPartitions);

        return await _adminClientBuilder.AlterConsumerGroupOffsetsAsync(groupPartitions, options);
    }

    public async Task<List<ListConsumerGroupOffsetsResult>> ListConsumerGroupOffsetsAsync(IEnumerable<ConsumerGroupTopicPartitions> groupPartitions, ListConsumerGroupOffsetsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.ListConsumerGroupOffsetsAsync(groupPartitions);

        return await _adminClientBuilder.ListConsumerGroupOffsetsAsync(groupPartitions, options);
    }

    public async Task<ListConsumerGroupsResult> ListConsumerGroupsAsync(ListConsumerGroupsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.ListConsumerGroupsAsync();

        return await _adminClientBuilder.ListConsumerGroupsAsync(options);
    }

    public async Task<DescribeConsumerGroupsResult> DescribeConsumerGroupsAsync(IEnumerable<string> groups, DescribeConsumerGroupsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.DescribeConsumerGroupsAsync(groups);

        return await _adminClientBuilder.DescribeConsumerGroupsAsync(groups, options);
    }

    public async Task<DescribeUserScramCredentialsResult> DescribeUserScramCredentialsAsync(IEnumerable<string> users, DescribeUserScramCredentialsOptions options = null)
    {
        if (options == null)
            return await _adminClientBuilder.DescribeUserScramCredentialsAsync(users);

        return await _adminClientBuilder.DescribeUserScramCredentialsAsync(users, options);
    }

    public async Task AlterUserScramCredentialsAsync(IEnumerable<UserScramCredentialAlteration> alterations, AlterUserScramCredentialsOptions options = null)
    {
        if (options == null)
            await _adminClientBuilder.AlterUserScramCredentialsAsync(alterations);
        else
        await _adminClientBuilder.AlterUserScramCredentialsAsync(alterations, options);
    }

    public void Dispose()
    {
        _adminClientBuilder.Dispose();
    }
}
