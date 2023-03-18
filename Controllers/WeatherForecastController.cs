using Microsoft.AspNetCore.Mvc;
using System;
using Tree;

namespace Tree.Controllers;

[ApiController]
[Route("tree")]
public class TreeController : ControllerBase
{
    private readonly ILogger<TreeController> _logger;

    public TreeController(ILogger<TreeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("int")]
    public int Get()
    {
        return  5;
    }
}
