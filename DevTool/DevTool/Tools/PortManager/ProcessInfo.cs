namespace DevTool.Tools.PortManager {
    public class ProcessInfo {
        public uint ProcessId { get; set; }
        public string IpSource { get; set; }
        public string PortSource { get; set; }
        public string IpDestin { get; set; }
        public string PortDestin { get; set; }
        public string Status { get; set; }
        public string Protocol { get; set; }
    }
}
