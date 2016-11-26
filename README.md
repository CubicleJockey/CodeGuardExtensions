# Code Guard Extensions by CubicleJockey

<hr />

Extensions Include:
* Custom Messages extensions for [CodeGuard](https://www.nuget.org/packages/Seterlund.CodeGuard/)

<hr />
<pre>
DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE 
Version 1, September 2016 

 Copyright (C) 2016 André Davis <CubicleJockey@users.noreply.github.com> 

 Everyone is permitted to copy and distribute verbatim or modified 
 copies of this license document, and changing it is allowed as long 
 as the name is changed. 

   DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE 
   TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION 

  0. You just DO WHAT THE FUCK YOU WANT TO.
</pre>
<hr />
<br />


#### Basic Examples

<pre>
Guard.That(false).IsFalse("I'm a custom message.");

var result = Guard.That(collection).IsNotEmpty("What am I supposed to do with an empty collection.").Value;
</pre>

#### Links

[EyeCatch NuGetpacker](http://www.eyecatch.no/blog/create-nuget-packages-easily/)
<br />
[Markdown CheatSheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)

<hr />

<a href="http://www.wtfpl.net/"><img
       src="http://www.wtfpl.net/wp-content/uploads/2012/12/wtfpl-badge-4.png"
       width="80" height="15" alt="WTFPL" /></a>
