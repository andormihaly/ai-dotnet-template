using AiDotNet.Application;
using AiDotNet.Domain.Common;
using AiDotNet.Infrastructure;
using NetArchTest.Rules;

namespace AiDotNet.ArchitectureTests;

public class LayerDependencyTests
{
    [Fact]
    public void Domain_Should_Not_Have_Dependency_On_Application()
    {
        var result = Types.InAssembly(typeof(BaseEntity).Assembly).ShouldNot().HaveDependencyOn("AiDotNet.Application").GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Domain_Should_Not_Have_Dependency_On_Infrastructure()
    {
        var result = Types.InAssembly(typeof(BaseEntity).Assembly).ShouldNot().HaveDependencyOn("AiDotNet.Infrastructure").GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Domain_Should_Not_Have_Dependency_On_Api()
    {
        var result = Types.InAssembly(typeof(BaseEntity).Assembly).ShouldNot().HaveDependencyOn("AiDotNet.Api").GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Application_Should_Not_Have_Dependency_On_Infrastructure()
    {
        var result = Types.InAssembly(typeof(ApplicationServicesRegistration).Assembly).ShouldNot().HaveDependencyOn("AiDotNet.Infrastructure").GetResult();

        Assert.True(result.IsSuccessful);
    }
    [Fact]
    public void Application_Should_Not_Have_Dependency_On_Api()
    {
        var result = Types.InAssembly(typeof(ApplicationServicesRegistration).Assembly).ShouldNot().HaveDependencyOn("AiDotNet.Api").GetResult();

        Assert.True(result.IsSuccessful);
    }
    [Fact]
    public void Infrastructure_Should_Not_Have_Dependency_On_Api()
    {
        var result = Types.InAssembly(typeof(InfrastructureServicesRegistration).Assembly).ShouldNot().HaveDependencyOn("AiDotNet.Api").GetResult();

        Assert.True(result.IsSuccessful);
    }
}
