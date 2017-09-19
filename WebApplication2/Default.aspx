<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <pre class="cscode"><code><span class="key">using</span> System;
<span class="key">using</span> System.Collections.Generic;

<span class="key">namespace</span> MyBlog1.Models
{
    <span class="key">public</span> <span class="key">class</span> Post
    {
        <span class="key">public</span> <span class="key">int</span> Id { <span class="key">get</span>; <span class="key">set</span>; }

        <span class="key">public</span> <span class="key">string</span> Title { <span class="key">get</span>; <span class="key">set</span>; }

        <span class="key">public</span> <span class="key">string</span> ShortDescription { <span class="key">get</span>; <span class="key">set</span>; }

        <span class="key">public</span> <span class="key">string</span> Description { <span class="key">get</span>; <span class="key">set</span>; }

        <span class="key">public</span> <span class="key">string</span> Meta { <span class="key">get</span>; <span class="key">set</span>; }

        <span class="key">public</span> <span class="key">string</span> UrlSlug { <span class="key">get</span>; <span class="key">set</span>; }

        <span class="key">public</span> <span class="key">bool</span> Published { <span class="key">get</span>; <span class="key">set</span>; }

        <span class="key">public</span> DateTime PostedOn { <span class="key">get</span>; <span class="key">set</span>; }

        <span class="key">public</span> DateTime? Modified { <span class="key">get</span>; <span class="key">set</span>; }

        <span class="key">public</span> <span class="key">int</span> CategoryId { <span class="key">get</span>; <span class="key">set</span>; }
        <span class="key">public</span> Category Category { <span class="key">get</span>; <span class="key">set</span>; }

        <span class="key">public</span> ICollection&lt;PostTag&gt; PostTags { <span class="key">get</span>; <span class="key">set</span>; }
    }
}
</code></pre>

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
