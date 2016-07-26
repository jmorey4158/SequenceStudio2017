# Sequence-Studio-2017
C#, Entity Framework, Delegates, Async, Multi-Threaded -- Updated and Re-Architected from 2013


<h2>What Is 'Sequence Studio'?</h2>
<p>Sequence Studio is a hobby project that I have been working on in my 'spare time'. It is built around a small subset of Bioinformatics functions. 
The code retrieves, stores and manipulates DNA, RNA, and Polypeptide (Protein) sequences. Hey, I'm into that sort of thing.</p>
<p> More specifically, the code provides the user to call APIs (in C#) to perform a query into the NCBI databases, store the results in a local DB
(working on Azure-izing this), manipulate the sequences, and store the queries and query results locally.</p>
<p> I've been rummaging around in this stack for a few years, as time permitted.</p>


<h2> What C# Techniques Did You Use?</h2>
<h3>Entity Framework</h3>
<p>The local storage is handled using the Entity Framework. I made this choice (over ADO.NET and T-SQL) because I was doing a
Code-First rendition and the data set is small. This way I could specify the POCOs and let EF create the SQL procs for me. 
Lazy? Maybe, but query performance wasn't a priority for this project.</p>
<p>However, the real beauty of this approach is that I can easily and smoothly point to a network DB, or one in the cloud, like an Azure DB, and not have to re-code. Awesome!</p>


<h3>Delegates</h3>
<p>Because the types of sequences are similar in many ways and the Methods that manipulate them are similar, 
I decided to use the Delegate Pattern to design the Methods. I passed both Interfaces and Delegates into Method calls to satisfy
this design pattern. </p>


<h3>Interfaces</h3>
<p>Interfaces aren't just for breakfast anymore. We can use them not only to define structure and implementation contracts, but also pass them as parameters into methods and return them as values from methods. Well, not really, we can pass any POCO that implements that Interface, by specifying the Interface in the param or return type.</p>
<p>I can hear some saying, 'Big Deal'. But it is because it really provides a mechanism for reducing DRY (Don't Repeat Yourself) by allowing a single method to use multiple types, but without causing validation headaches.</p>
<p>I used Interface Definitions and passed the Interfaces into Methods as params and 
returned them as values from Methods. This solved a number of DRY problems I was having in the last version.</p>


<h3>Asynchronous Methods</h3>
<p>I'm not sure how I got this far without using async / await pattern, but there it is. In this upgrade of Sequence Studio, 
as part of the re-architecture, I refactored a lot of my cross-boundary methods as asynchronous. But I did so strategically.
<p>I created what I call the "Async Wall" pattern where I use a public method that takes in only POCOs form the Presentation Layer (what’s this? See Devu.com Application architecture). This method then calls private / protected methods that take in native types and custom types and hand back POCOs. This way I can assure that the inputs from the Presentation Layer or Application Service Layer are valid and that I am handing back valid objects.</p>
<p> This pattern fulfills both Separation of Concerns and Encapsulation and allows for future expansion / tweaking of the Business Layer without requiring changes to other layers.</p>


<h3>Multi-Threading and TPL</h3>
<p>In this incarnation of SS, again, as part of the re-architecture, I implemented both thread-safe types and methods but also 
performance improvements using the Task Parallel Library (TPL) and the .AsParallel static method where needed. This greatly 
improved performance on my multi-core test box but also in the cloud, where Azure can throw as many cores at some of the more
resource-intensive operations as you can shake the proverbial stick at. Awesome.<p>
<p>Of course, I reserved the TPL work for the layers that reside on scalable environments, like the Application Servie Layer, Business Layer, and Persistence Layer. I used the "Async Wall" Pattern to make the Presentation Layer as skinny as practical.</p>


<h3>New C# 6.0 Features</h3>
<p>C# is always getting better and better and I want to make sure I am using the great new features. Here are some of them:</p>
<ul>
<li>String Interpolation</li>
<li>Expression Body Syntax</li>
</ul>

<h3>Good Ol' C# Features</h3>
<p>Of course, there are a ton of features that have been part of C# for years, but are still a staple of good developement. The Oldies But Goodies.Here are some of them I used throughout the project:</p>
<ul>
<li>LINQ and Lambda Expressions</li>
<li>Regex and Regular Expressions</li>
<li>Generics</li>
</ul>

<h2>Special Thanks to Bob Tabor and DevU.com</h2>
<p>Shout-Out to Bob Tabor of DevU.com, especially his series on Application Architecture. 
Bob is a First-Class Educator and his series on Application architecture really opened my eyes to the amazing possibilities 
in C#. Most notably, the separation of concerns, delegates, passing Interfaces, and many more. If you are in search 
of Programming Awesomeness, go to DevU.com. -- OK, end of shameless plug!</p>

