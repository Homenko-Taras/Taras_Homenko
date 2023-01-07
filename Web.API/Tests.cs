namespace WebAPI
{

    public class Tests
    {
        [Test, Order(1)]
        public void CanPutFile()
        {
            var client = new Dropbox();
            client.PutFile("../../../test.txt", "/WebAPI/test.txt");
        }

        [Test, Order(2)]
        public void CanGetFileInfo()
        {
            var client = new Dropbox();
            var metadata = client.GetFileInfo("/WebAPI/test.txt");

            JToken sizeToken, modifiedToken;
            Assert.IsTrue(metadata.TryGetValue("size", out sizeToken));
            Assert.IsTrue(metadata.TryGetValue("name", out modifiedToken));
        }

        [Test, Order(3)]
        public void CanRemoveFile()
        {
            var client = new Dropbox();
            client.RemoveFile("/WebAPI/test.txt");
        }
    }
}

