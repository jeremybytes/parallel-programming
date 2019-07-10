# Run Faster: Parallel Programming in .NET

Want to see code run 7 times faster? Here we use parallel programming to make full use of our multi-core systems. Techniques include .NET Parallel.ForEach and also spinning up Tasks manually to take more control over the process. Along the way, we see how to write code that is easy to run in parallel (warning: it may start you down the path of functional programming). Use the hardware you have to run faster.

## Code Samples
* **NonParalellizable**  
This is the "Mazes" project that is difficult to make parallel due to the nature of the algorithms. The algoritms all require sequential processing, meaning that the next step cannot be computed until the previous step has been completed.

* **ParallelFor**  
This is the "Conway's Game of Life" project. This shows how to use Parallel.For to run multiple tasks in parallel. In addition, the "conway-performance" project compares different levels of parallel performance using Parallel.For and Task.

* **ParalleWithTask**  
This is the "Digit Recognition" project that contains console applications to show single-threaded as well as parallel computation. There is also a desktop application to show performance differences side-by-side.

## Links
* [I'll Get Back to You: Task, Await, and Asynchronous Programming](http://www.jeremybytes.com/Demos.aspx#TaskAndAwait)  
A series of articles and videos that introduces to Task & Await

* [Digit Recognition](https://github.com/jeremybytes/digit-display)  
A series of articles about the Digit Recognition project

* [Jeremy Explores Mazes for Programmers](https://github.com/jeremybytes/mazes-for-programmers)  
A series of articles that about the book *Mazes for Programmers* that lead to the "Mazes" project

* [TDD and Conway's Game of Life](http://www.jeremybytes.com/Demos.aspx#TDD)  
A series of articles and videos exploring Conway's Game of Life

* [Book Review: Parallel Programming with Microsoft .NET](https://jeremybytes.blogspot.com/2014/02/book-review-parallel-programming-with.html)  
The book is from 2010 but is still relevant (particularly the introduction on selecting the right patterns). The book itself is available online here: [Parallel Programming with Microsoft .NET](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/ff963553(v=pandp.10)). Although the Microsoft Docs lists it as no longer maintained, there is no direct equivalent.

--- 