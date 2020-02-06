using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IpNotif.Core;

namespace IpNotif.Gui {
    public partial class MainForm : Form {

        private Timer _timer;
        private EventHandler OnIpChanged;
        
        #region Properties
        public List<string> IpHistory { get; set; }

        public int CheckIpInterval {
            get => _timer.Interval;
            set => _timer.Interval = value;
        }

        public bool DisableCheckIp {
            get => !_timer.Enabled;
            set => _timer.Enabled = !value;
        }

        public string LatestIp {
            get {
                if(IpHistory.Any()) {
                    return IpHistory.LastOrDefault();
                }
                return null;
            }
        }

        public string PublicIpAddress {
            get => ExternalIpProvider.GetExternalIPAddress();
        }

        #endregion

        #region Methods
        private void Init() {
            _timer = new Timer {
                Interval = 10000,
                Enabled = true
            };
            _timer.Tick += On_timer_Tick;
            IpHistory = new List<string>();
        }
        private void On_timer_Tick(object sender, EventArgs e) {
            CheckForIpChange();
        }

        public void AddToHistory(string ip) {
            if (IpHasChanged(ip))
                IpHistory.Add(ip);
            else if(!IpHistory.Any())
                IpHistory.Add(ip);
        }

        public bool IpHasChanged(string newIp) {
            if (!string.IsNullOrEmpty(LatestIp) && newIp != LatestIp)
                return true;
            return false;
        }

        public void CheckForIpChange() {
            var external_ip = PublicIpAddress;
            if (IpHasChanged(external_ip)) {
                NotifyUserAboutIpChange();
            }
            AddToHistory(external_ip);
        }

        public void NotifyPublicIpForFirstTime() {
            var external_ip = PublicIpAddress;
            AddToHistory(external_ip);
            notifyIcon.BalloonTipTitle = notifyIcon.Text = "IpNotify";
            notifyIcon.BalloonTipText = $"Your public IP is : {LatestIp}";
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.Text = $"IpNotify : {LatestIp}";
            notifyIcon.ShowBalloonTip(5000);
        }

        public void NotifyUserAboutIpChange() {
            notifyIcon.Text = notifyIcon.BalloonTipTitle = "IpNotify";
            notifyIcon.BalloonTipText = $"Your public IP has changed to : {LatestIp}";
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.Text = $"IpNotify : {LatestIp}";
            notifyIcon.ShowBalloonTip(5000);
        }

        #endregion


        public MainForm() {
            InitializeComponent();
            Init();
            NotifyPublicIpForFirstTime();
        }


        


    }
}
