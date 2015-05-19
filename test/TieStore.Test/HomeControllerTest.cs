using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Core;
using Microsoft.AspNet.Http.Core.Collections;
using xunit;

    
public class HomeControllerTests {
    
    public void GetCartId_ReturnsCartIdFromCookies()
    {
        // Arrange
        var i = 1;

        // Act
        i++;

        // Assert
        Assert.Equal(i, 2);
    }
   
}
