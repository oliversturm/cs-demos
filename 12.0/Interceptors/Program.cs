using Interceptors;

var ds = new DoesSomething();
ds.DoSomething(10); // We'll intercept this with interceptor 1
ds.DoSomething(20); // We'll intercept this with interceptor 2
ds.DoSomething(30); // We'll intercept this with interceptor 2
ds.DoSomething(40); // We'll leave this one alone

