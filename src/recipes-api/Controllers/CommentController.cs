using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("comment")]
public class CommentController : ControllerBase
{  
    public readonly ICommentService _service;
    
    public CommentController(ICommentService service)
    {
        this._service = service;        
    }

    // 10 - Sua aplicação deve ter o endpoint POST /comment
    [HttpPost]
    public IActionResult Create([FromBody]Comment comment)
    {
        try
        {
            this._service.AddComment(comment);
            return CreatedAtAction(null, null, comment);
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    // 11 - Sua aplicação deve ter o endpoint GET /comment/:recipeName
    [HttpGet("{recipeName}", Name = "GetComment")]
    public IActionResult Get(string recipeName)
    {
        try
        {
            List<Comment> comments = this._service.GetComments(recipeName);
            return Ok(comments);
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }
}