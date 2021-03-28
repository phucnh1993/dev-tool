using DevTool.Services.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DevTool.Tools.PortManager {
    public partial class PortManager : Form {
        private ProcessInfo _data;
        private List<ProcessInfo> _datas;
        private int _columnIndex;
        private bool _asc;

        public PortManager() {
            InitializeComponent();
            _data = new ProcessInfo();
            _datas = new List<ProcessInfo>();
            _columnIndex = 0;
            _asc = true;
        }

        private void btnRefesh_Click(object sender, EventArgs e) {
            GetDataFromCommand();
            processId.Text = "";
            ipSource.Text = "";
            portSource.Text = "";
            ipDestin.Text = "";
            portDestin.Text = "";
            processStatus.Text = "";
            processProtocol.Text = "";
            this.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            _data.Protocol = processProtocol.Text;
            _data.IpSource = ipSource.Text;
            _data.PortSource = portSource.Text;
            _data.IpDestin = ipDestin.Text;
            _data.PortDestin = portDestin.Text;
            _data.Status = processStatus.Text;
            uint pid = 0;
            if (uint.TryParse(processId.Text, out pid)) {
                _data.ProcessId = pid;
            }
            GetDataFromCommand();
            _datas = _datas.Where(x => ((_data.ProcessId > 0 && x.ProcessId == _data.ProcessId) || _data.ProcessId <= 0)
                && ((!string.IsNullOrEmpty(_data.Protocol) && x.Protocol == _data.Protocol) || string.IsNullOrEmpty(_data.Protocol))
                && ((!string.IsNullOrEmpty(_data.IpSource) && x.IpSource == _data.IpSource) || string.IsNullOrEmpty(_data.IpSource))
                && ((!string.IsNullOrEmpty(_data.PortSource) && x.PortSource == _data.PortSource) || string.IsNullOrEmpty(_data.PortSource))
                && ((!string.IsNullOrEmpty(_data.IpDestin) && x.IpDestin == _data.IpDestin) || string.IsNullOrEmpty(_data.IpDestin))
                && ((!string.IsNullOrEmpty(_data.PortDestin) && x.PortDestin == _data.PortDestin) || string.IsNullOrEmpty(_data.PortDestin))
                && ((!string.IsNullOrEmpty(_data.Status) && x.Status == _data.Status) || string.IsNullOrEmpty(_data.Status))).ToList();
            processDataSource.DataSource = null;
            processDataSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            processDataSource.DataSource = _datas;
            this.Refresh();
        }

        private void bynKillProcess_Click(object sender, EventArgs e) {
            _data.Protocol = processProtocol.Text;
            _data.IpSource = ipSource.Text;
            _data.PortSource = portSource.Text;
            _data.IpDestin = ipDestin.Text;
            _data.PortDestin = portDestin.Text;
            _data.Status = processStatus.Text;
            uint pid = 0;
            if (uint.TryParse(processId.Text, out pid)) {
                _data.ProcessId = pid;
            }
            var temp = _datas.Where(x => ((_data.ProcessId > 0 && x.ProcessId == _data.ProcessId) || _data.ProcessId <= 0)
                && ((!string.IsNullOrEmpty(_data.Protocol) && x.Protocol == _data.Protocol) || string.IsNullOrEmpty(_data.Protocol))
                && ((!string.IsNullOrEmpty(_data.IpSource) && x.IpSource == _data.IpSource) || string.IsNullOrEmpty(_data.IpSource))
                && ((!string.IsNullOrEmpty(_data.PortSource) && x.PortSource == _data.PortSource) || string.IsNullOrEmpty(_data.PortSource))
                && ((!string.IsNullOrEmpty(_data.IpDestin) && x.IpDestin == _data.IpDestin) || string.IsNullOrEmpty(_data.IpDestin))
                && ((!string.IsNullOrEmpty(_data.PortDestin) && x.PortDestin == _data.PortDestin) || string.IsNullOrEmpty(_data.PortDestin))
                && ((!string.IsNullOrEmpty(_data.Status) && x.Status == _data.Status) || string.IsNullOrEmpty(_data.Status))).FirstOrDefault();
            List<string> cmd = new List<string>();
            cmd.Add(string.Format("taskkill /PID {0} /F", temp.ProcessId));
            CommandLineController.RunCommandLine(cmd);
            GetDataFromCommand();
        }

        public void GetDataFromCommand() {
            List<string> cmd = new List<string>();
            cmd.Add("netstat -ano");
            var data = CommandLineController.ReadCommandLine(cmd);
            uint index = 0;
            _datas.Clear();
            result.Text = "Total process: " + (data.Count - 10);
            foreach (var item in data) {
                if (index > 9 && item != "" && (item.Contains("TCP") || item.Contains("UDP"))) {
                    var pmm = new ProcessInfo();
                    int len = item.Length;
                    string line = item.Trim();
                    int start = line.IndexOf(' ');
                    pmm.Protocol = line.Substring(0, start);
                    //---------------------------------------------------------------------------
                    line = line.Substring(start + 1);
                    line = line.TrimStart();
                    start = line.IndexOf(' ');
                    string subString = line.Substring(0, start);
                    int startPort = subString.LastIndexOf(':');
                    pmm.IpSource = subString.Substring(0, startPort);
                    pmm.PortSource = subString.Substring(startPort + 1);
                    //---------------------------------------------------------------------------
                    line = line.Substring(start + 1);
                    line = line.TrimStart();
                    start = line.IndexOf(' ');
                    subString = line.Substring(0, start);
                    startPort = subString.LastIndexOf(':');
                    pmm.IpDestin = subString.Substring(0, startPort);
                    pmm.PortDestin = subString.Substring(startPort + 1);
                    //---------------------------------------------------------------------------
                    line = line.Substring(start + 1);
                    line = line.TrimStart();
                    start = line.IndexOf(' ') == -1 ? line.Length : line.IndexOf(' ');
                    uint pid = 0;
                    if (uint.TryParse(line.Substring(0, start), out pid)) {
                        pmm.Status = "EMPTY";
                        pmm.ProcessId = pid;
                    } else {
                        pmm.Status = line.Substring(0, start);
                        line = line.Substring(start + 1);
                        pmm.ProcessId = uint.Parse(line);
                    }
                    _datas.Add(pmm);
                }
                index++;
            }
            result.Text += "\r\nTotal ip source: " + _datas.Select(x => x.IpSource).Distinct().Count();
            result.Text += "\r\nTotal ip destin: " + _datas.Select(x => x.IpDestin).Distinct().Count();
            result.Text += "\r\nTotal port open: " + _datas.Select(x => x.PortSource).Distinct().Count();
            processDataSource.DataSource = null;
            processDataSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            processDataSource.DataSource = _datas;
            this.Refresh();
        }

        private void processDataSource_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (processDataSource.SelectedRows.Count > 0) {
                DataGridViewRow row = processDataSource.SelectedRows[0];
                processId.Text = row.Cells[0].Value.ToString();
                ipSource.Text = row.Cells[1].Value.ToString();
                portSource.Text = row.Cells[2].Value.ToString();
                ipDestin.Text = row.Cells[3].Value.ToString();
                portDestin.Text = row.Cells[4].Value.ToString();
                processStatus.Text = row.Cells[5].Value.ToString();
                processProtocol.Text = row.Cells[6].Value.ToString();
                this.Refresh();
            }
            if (processDataSource.SelectedCells.Count > 0) {
                var cell = processDataSource.SelectedCells[0];
                switch (cell.ColumnIndex) {
                    case 0:
                        processId.Text = cell.Value.ToString();
                        break;
                    case 1:
                        ipSource.Text = cell.Value.ToString();
                        break;
                    case 2:
                        portSource.Text = cell.Value.ToString();
                        break;
                    case 3:
                        ipDestin.Text = cell.Value.ToString();
                        break;
                    case 4:
                        portDestin.Text = cell.Value.ToString();
                        break;
                    case 5:
                        processStatus.Text = cell.Value.ToString();
                        break;
                    case 6:
                        processProtocol.Text = cell.Value.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void processDataSource_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            _asc = !((_columnIndex == e.ColumnIndex) && _asc);
            _columnIndex = e.ColumnIndex;
            switch (_columnIndex) {
                case 0:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.ProcessId).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.ProcessId).ToList();
                    break;
                case 1:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.IpSource).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.IpSource).ToList();
                    break;
                case 2:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.PortSource).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.PortSource).ToList();
                    break;
                case 3:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.IpDestin).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.IpDestin).ToList();
                    break;
                case 4:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.PortDestin).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.PortDestin).ToList();
                    break;
                case 5:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.Status).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.Status).ToList();
                    break;
                case 6:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.Protocol).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.Protocol).ToList();
                    break;
                default:
                    break;
            }
            processDataSource.DataSource = null;
            processDataSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            processDataSource.DataSource = _data;
        }

        private void PortManager_Load(object sender, EventArgs e) {
            GetDataFromCommand();
        }
    }
}
