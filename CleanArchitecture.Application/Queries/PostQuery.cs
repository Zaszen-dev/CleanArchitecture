﻿
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries;

public class PostQuery : IRequest<List<Post>>
{
}
