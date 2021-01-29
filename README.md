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

<code>
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
</code>
