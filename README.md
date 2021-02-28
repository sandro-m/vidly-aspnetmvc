<h1 align="center">Vidly</h1>

<p>Projeto ASP NET MVC do curso <a target="_blank" href='https://www.udemy.com/course/the-complete-aspnet-mvc-5-course/'>The Complete ASP.NET MVC 5 Course</a> por <a target="_blank" href='https://www.udemy.com/user/moshfeghhamedani/'>Mosh Hamedani</a>.</p>

<h2>1. Introdução</h2>

<p>O projeto Vidly é uma aplicação web para alugar filmes.</p>

<p>Futuramente, existirá duas funções nesta aplicação web:</p>

<ul>
  <li>Administrador</li>
  <li>Funcionário</li>
</ul>

<p>Módulos habilitados para o Administrador:</p>

<ul>
  <li>Listar, criar, Editar e Excluir os clientes;</li>
  <li>Listar, criar, Editar e Excluir os Filmes;</li>
  <li>Registrar o aluguel de filmes.</li>
</ul>

<p>Módulos habilitados para o Funcionário:</p>

<ul>
  <li>Listar os clientes;</li>
  <li>Listar os Filmes;</li>
  <li>Registrar o aluguel de filmes.</li>
</ul>

<h2>2. Padrão de Arquiterura - MVC (Model-View-Controller)</h2>

![MVC](https://user-images.githubusercontent.com/26336105/104821333-c48e0300-5819-11eb-9299-f1edeba7acd9.jpg)

<h2>3. Confirugando Ambiente de Desenvolvimento</h2>

<p>Faça download e instale <a href="https://marketplace.visualstudio.com/items?itemName=VisualStudioPlatformTeam.ProductivityPowerTools2013">Productivity Power Tools 2013</a></p>
<p>Faça download e instale <a href="https://marketplace.visualstudio.com/items?itemName=MadsKristensen.WebEssentials20135">Web Essentials 2013.5</a></p>

<h2>4. Criar Aplicação ASP NET MVC 5</h2>

<p>File > New > Project > ASP .NET Web Application > Select Template: MVC (Authentication: Individual User Account) > 'Click Ok'</p>

<h2>5. MVC em Ação</h2>

<ul>
  <li>Adicionado uma nova classe na pasta Models, Movie.cs;</li>
  <li>Adicionado MovieController na pasta Controllers;</li>
  <li>Adicionado RandomView na pasta ~/Views/Movies.</li>
</ul>

Ao entrar na URL http://localhost:XXXXX/Movies/Random, o controller atenderá a sua requisição e retornará a view Random.

<h2>6. Adicionando um tema</h2>

<ul>
  <li>Faça download <a href="https://bootswatch.com/lumen/">Bootstrap Lumen</a>;</li>
  <li>Renomear para 'boostrap-lumen.css' e cole o CSS na pasta Content do projeto Vidly;</li>
  <li>No arquivo BundleConfig.cs, alterar a '~/Content/bootstrap.css' para '~/Content/bootstrap-lumen.css'.</li>
</ul>

<h2>7. Layout do Curso</h2>

<ul>
  <li>ASP .NET MVC Fundamentals;</li>
  <li>Entity Framework (Code-first);</li>
  <li>Forms;</li>
  <li>Validation;</li>
  <li>Build RESTful Services;</li>
  <li>Client-side Development;</li>
  <li>Autenticação e Autorização;</li>
  <li>Otimização da Performance;</li>
  <li>Criar Feature End-To-End.</li>
</ul>

<h2>8. Action Results</h2>

<table>
  <tr>
    <th>Types</th>
    <th>Helper Method</th>
  </tr>
  <tr>
    <td>ViewResult</td>
    <td>View()</td>
  </tr>
  <tr>
    <td>PartialViewResult</td>
    <td>PartialView()</td>
  </tr>
  <tr>
    <td>ContentResult</td>
    <td>Content()</td>
  </tr>
  <tr>
    <td>RedirectResult</td>
    <td>Redirect()</td>
  </tr>
  <tr>
    <td>RedirectToRouteResult</td>
    <td>RedirectToAction()</td>
  </tr>
  <tr>
    <td>JsonResult</td>
    <td>Json</td>
  </tr>
  <tr>
    <td>FileResult</td>
    <td>File()</td>
  </tr>
  <tr>
    <td>HttpNotFoundResult</td>
    <td>HttpNotFound()</td>
  </tr>
  <tr>
    <td>EmptyResult</td>
    <td></td>
  </tr>
</table>

<pre><code class='language-cs'>
public ActionResult Random() {
  
    var movie = new Movie()
    {
        Id = 1,
        Name = "Shrek"
    };

    //return View(movie);                     <--- Retorna a View (~/Views/Home/Random) com o objeto do tipo Movie
    //return Content("Hello World");          <--- Retorna uma página com fundo branco escrito "Hello World"
    //return HttpNotFound();                  <--- Retorna uma página de mensagem de erro 404
    //return new EmptyResult();               <--- Retorna uma página em branco
    return RedirectToAction("Index", "Home"); <--- Retorna a página principal da Aplicação
}
</code></pre>

<h2>9. Action Parameters</h2>

Parameters Source:

<ul>
  <li>Na URL: /movie/edit/1</li>
  <li>Na Query String: /movie/edit?id=1</li>
  <li>No Dados de Formulário: id=1</li>
</ul>

<h4>9.1 Criar Função no MoviesController</h4>

<pre><code class='language-cs'>
public ActionResult Edit(int id)
{
    return Content("id: " + id);
}
</code></pre>

Acessando a URL http://localhost:00000/movies/edit/1 retorna a página apresentado valor 'id = 1'.

Se alterarmos o parâmetro 'id' para 'movieId', apresentará um Exceção, pois no arquivo '~/App_Start/RouteConfig.cs' contém uma Rota Mapeada com o nome do parâmetro como 'id':

<pre><code class='language-cs'>
public static void RegisterRoutes(RouteCollection routes)
{
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    <b>routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    );</b>
}
</code></pre>

Você pode alterar o '{id}' para '{movieId}' para funcionar, mas a URL '/movies/edit/1' apresentaria Exceção. Outrar alternativa sem mudar o MapRoute é utilizar o Query String (/movies/Edit?id=1) para acessar a Action.

<h4>9.2 Criar Função no MoviesController com parâmetros opcionais</h4>

<pre><code class='language-cs'>
public ActionResult Index(int? pageIndex, string sortBy)
{
    if (!pageIndex.HasValue)
        pageIndex = 1;
    if (string.IsNullOrWhiteSpace(sortBy))
        sortBy = "Name";
    return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
}
</code></pre>

Para criar função com parâmetros opcionais:

<ol>
  <li>Colocar Váriaveis como 'Nullables';</li>
  <li>Nesse caso, inserir '?' na frente do 'int' para aceitar o valor 'null' e o tipo 'string' já aceita 'null' como padrão.</li>
</ol>

Acessando a URL "/movies?pageIndex=1&sortBy=Date", retornará página com os valores passados pela URL ('pageIndex=1&sortBy=Date').

<h2>10. Convention-based Routes</h2>

<h4>10.1 Múltiplos Parâmetros</h4>

Exemplo: "/movies/released/2015/04"

1° Inserir a rota customizada no arquivo RouteConfig.cs:
<pre><code class='language-cs'>
<b>routes.MapRoute(
	"moviesByReleaseDate",
	"movies/released/{year}/{month}",
	new { controller = "Movies", action = "ByReleaseDate" }
);
</b>
routes.MapRoute(
	name: "Default",
	url: "{controller}/{action}/{id}",
	defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
);
</code></pre>

2° Criar uma função no MoviesController:
<pre><code class='language-cs'>
public ActionResult ByReleaseDate(int year, int month)
{
	return Content(year + "/" + month);
}
</code></pre>

Caso seja necessário restringir a quantidade de dígitos de cada parâmetro:
<pre><code class='language-cs'>
routes.MapRoute(
	"moviesByReleaseDate",
	"movies/released/{year}/{month}",
	new { controller = "Movies", action = "ByReleaseDate" },
	<b>new { year = @"\d{4}", month= @"\d{2}" }</b>
);
</code></pre>

<p>Entrando na URL http://localhost:00000/movies/released/2021/1 apresentará erro 404 Not Found.</p>
<p>Entrando na URL http://localhost:00000/movies/released/2021/01 retornará o conteúdo.</p>

<h2>11. Atributos de Rotas</h2>

<p>Deixando o mapeamento de rotas mais limpo.</p>

<p>1° Apagar a linha de código da rota customizada e substitua pelo código abaixo:</p>
<pre><code class='language-cs'>
	routes.MapMvcAttributeRoutes();
</code></pre>
<p>2° Adicione o atributo no MoviesController</p>
<pre><code class='language-cs'>
<b>[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]</b>
public ActionResult ByReleaseDate(int year, int month)
{
	return Content(year + "/" + month);
}
</code></pre>
<p>Para mais informações consulte <a href="https://dotnettutorials.net/lesson/attribute-route-constraints-mvc/">Attribute Route Constraints in ASP.NET MVC</a></p>

<h2>12. Passando dados pela Views (Jeito Estranho!!!)</h2>

<h4>12.1 ViewData</h4>

<p>É um dicionário de objetos, e só deveria ser usado quando não se sabe a composição do que será o objeto, já que os elementos não possuem tipos e sintaxe de acesso a eles um pouco desconfortável.</p>

<p>Alterar a ação Random no MoviesController:</p>

<pre><code class='language-cs'>
public ActionResult Random()
{
	var movie = new Movie()
	{
		Id = 1,
		Name = "Shrek"
	};

	<b>ViewData["Movie"] = movie;</b>
	return View();
}
</code></pre>

<p>Alterar a Random View:</p>
<pre><code class='html'>
<b>@using vidly_aspnetmvc.Models</b>
@{
    ViewBag.Title = "Random";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
<b><h2>@( ((Movie)ViewData["Movie"]).Name)</h2></b>
</code></pre>

<h4>12.2 ViewBag</h4>

<p>É um objeto dinâmico com propriedades criadas no controlador e que é acessível na visão, depois disto ela desaparece.</p>

<p>Alterar a ação Random no MoviesController:</p>

<pre><code class='language-cs'>
public ActionResult Random()
{
	var movie = new Movie()
	{
		Id = 1,
		Name = "Shrek"
	};

	//ViewData["Movie"] = movie;
	<b>ViewBag.Movie = movie;</b>
	return View();
}
</code></pre>

<p>Alterar a Random View:</p>
<pre><code class='html'>
<b>@using vidly_aspnetmvc.Models</b>
@{
    ViewBag.Title = "Random";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
<h2>@*@( ((Movie)ViewData["Movie"]).Name)*@</h2>
<b><h2>@ViewBag.Movie.Name</h2></b>
</code></pre>

<h2>13. View Models</h2>

<p>Criar uma classe Customer:</p>

<pre><code class='language-cs'>
<b>public class Customer
{
	public int Id { get; set; }
	public string Name { get; set; }
}</b>
</code></pre>

<p>Criar uma pasta 'ViewsModels' na raiz do projeto e criar uma classe 'RandomMoviesViewModel':</p>

<pre><code class='language-cs'>
<b>public class RandomMoviesViewModel
{
	public Movie Movie { get; set; }
	public List<Customer> Customers { get; set; }
}</b>
</code></pre>

<p>Alterar a ação Random no MoviesController:</p>

<pre><code class='language-cs'>
public ActionResult Random()
{
	var movie = new Movie()
	{
		Id = 1,
		Name = "Shrek"
	};
	<b>var customers = new List<Customer>
	{
		new Customer { Id = 1, Name = "Philip" },
		new Customer { Id = 2, Name = "Trevor" }
	};

	<b>var viewModel = new RandomMoviesViewModel()
	{
		Movie = movie,
		Customers = customers
	};
	return View(viewModel);</b>
}
</code></pre>

<p>Alterar a Random View:</p>
<pre><code class='html'>
<b>@model vidly_aspnetmvc.ViewsModels.RandomMoviesViewModel</b>
@{
    ViewBag.Title = "Random";
    Layout = "~/Views/Shared/_Layout.cshtml";
}
<b><h2>@Model.Movie.Name</h2></b>
</code></pre>