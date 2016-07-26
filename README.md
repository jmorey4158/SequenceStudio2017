# Sequence-Studio-2017
C#, Entity Framework, Delegates, Async, Multi-Threaded -- Updated and Re-Architected from 2013

<h2>What Is 'Sequence Studio'?</h2>
<p>Sequence Studio is a hobby project that I have been working on in my 'spare time'. It is built around a small bubset of Bioinformatics functions. 
The code retrieves, stores and manipulates DNA, RNA, and Poypeptide (Protein) sequences. Hey, I'm into that sort of thing.</p>
<p> More specifically, the code provides the user to call APIs (in C#) to perform a query into the NCBI databases, store the results in a local DB
(working on Azure-izing this), manipulate the sequences, and store the queries and query results locally.</p>
<p> I've been rumaging around in this stack for a few years, as time permitted.</p>

<h2>What Is The Data Flow?</h2>

<h2> What C# Techniques Did You Use?</h2>
<h3>Entity Framwork</h3>
<p>The local storage is handled using the Entity Framework. I made this coie (over ADO.NET and T-SQL) because I was doing a
Code-First rendition and the data set is small. This way I could specify the POCOs and let EF create the SQL procs for me. 
Lazy? Maybe, but query performance wasn't a priority for this project.</p>

<h3>Delegates</h3>
<p>Because the types of sequences are similar in many ways and the Methods that manipulate them are similar, 
I decided to use the Delegate Pattern to design the Methods. I passed both Interfaces and Delegates into Method calls to saticefy
this design pattern. </p>

<h3>Interfaces As Objects</h3>
<p>This Pattern is also called by other names, but I like this one. I used Interface Definitions and passed the Interfaces into Methods as params and 
returned tham as values from Methods. This solved a number of DRY (Don't Repeat Yourself) problems I was having in the last version.</p>

<h3>Asynchronous Methods</h3>
<p>I'm not sure how I got this far without using async / await pattern, but there it is. In this upgrade of Sequence Studio, 
as part of the re-architecture, I refactored a lot of my cross-boundary methods as asyncronous. But I did so strategically.

<p>I created what I call the "Async Wall" pattern where I use a public method that takes in only POCOs form the Presentation Layer (wht's this? See Devu.com Application architecture). This method then calls private / protected mehods that take in native types and custom types and hand back POCOs. This way I can assure that the inputs from the Presentation Layer or Application Service Layer are valid and that I am handing back valid objects.</p>


<h2>Special Thanks to Bob Tabor and DevU.com</h2>
<p>Shout-Out to Bob Tabor of DevU.com, especially his series on Application Architecture. 
Bob is a First-Class Educator and his series on Application architecture really opned my eyes to the amazing possibilities 
in C#. Most notably, the seperation of concerns, delegates, passing Interfaces, and many more. If you are in search 
of Programming Awesomeness, go to DevU.com. -- OK, end of shameless plug!</p>

