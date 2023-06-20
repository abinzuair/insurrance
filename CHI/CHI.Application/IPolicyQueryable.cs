using System.Linq.Expressions;
using CHI.Domain.Entities;

namespace CHI.Application;

public interface IPolicyQueryable<TResult>
{
    Expression<Func<InsurancePolicy, TResult>> QuerySelector();
}