# BlazorWebAppErrorBoundary
<p>
    This app is based on the <b>Blazor Web App</b> project template using <b>Global Auto Interactive render mode</b>.
</p>
<p>
    The app demonstrates the use of the <b>ErrorBoundary</b> component for <b>global error handling</b>.
</p>

<p>
  The project contains two pages using a button click event to load data fom the server. When throwing an exception on the server I expect that this should be caught and handled by the ErrorBoundary component 
as it does in the example when not using Ant components. However when data loading is triggered from an Ant button the exception never reaches the ErrorBoundary.
</p>
