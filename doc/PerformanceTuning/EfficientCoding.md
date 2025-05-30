Efficient coding
==============

#  Use readonly variables wherever possible

Normally the runtime checks every variable before accessing it. This takes time. A readonly variable is checked only once when setting it.

ReSharper shows recommendation for making a variable readonly. Normally you should follow it.

# Use string.Empty instead of ""

For example if you want to apply a empty string to a variable use string.Empty instead of "". This saves one unnecessary string allocation and later the garbage collection.

Bad

``` csharp

string s = "";

```

Good

``` csharp

string s = string.Empty;

```

# Recycle frequently used objects

This idea applies mainly for small and heavyly used objects with a short lifetime. The shorter the life time the more the time for object allocation and later garbage collection is influencing the app performance negatively when heavily used.

Implement interface IResettable for the classes used heavily. Then use BufferPool<T> to reuse the already create instances. With BufferPool<T>.Dequeue you get a instance of T to use and with BufferPool<T>.Enqueue you give it back to the pool.

# Use StringBuilder instead of string to build strings

String allocations are relatively expansive. Unnecessary string allocations should be avoided whereever it is possible.

Bad

``` csharp

var s = "My string"

s = s + GetAString()

....

private string GetAString()
{
	// Create a string as required
	return " with sample data";
}

```

Better

``` csharp

var s = new StringBuilder();

s.Append("My string");
s.Append(GetAString());

....

private string GetAString()
{
	// Create a string as required
	return " with sample data";
}

```

Best

``` csharp

var s = new StringBuilder();

s.Append("My string");
GetAString(s);

....

private void GetAString(StringBuilder s)
{
	// Create a string as required
	s.Append(" with sample data");
}

```
