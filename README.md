# Code Guard Extensions by CubicleJockey

<hr />

Extensions Include:
* Custom Messages extensions for [CodeGuard](https://www.nuget.org/packages/Seterlund.CodeGuard/)

<hr />

#### Basic Examples

```csharp
Guard.That(false).IsFalse("I'm a custom message.");

var result = Guard.That(collection).IsNotEmpty("What am I supposed to do with an empty collection.").Value;
```

#### Links

[EyeCatch NuGetpacker](http://www.eyecatch.no/blog/create-nuget-packages-easily/)
<br />
[Markdown CheatSheet](https://guides.github.com/features/mastering-markdown/)

<hr />

<a href="http://www.wtfpl.net/"><img
       src="http://www.wtfpl.net/wp-content/uploads/2012/12/wtfpl-badge-4.png"
       width="80" height="15" alt="WTFPL" /></a>
