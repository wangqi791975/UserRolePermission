namespace HC.JiShi.UserRole.Service
{
    public class Result
    {
        private bool _isSuccess = true;
        private string _message = "";

        public bool IsSuccess
        {
            get { return _isSuccess; }
            set { _isSuccess = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public void SetIsSuccessFalse(string message)
        {
            _isSuccess = false;
            _message = message;
        }
    }
}