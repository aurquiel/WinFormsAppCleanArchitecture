using Microsoft.Extensions.DependencyInjection;

namespace WinFormsAppCleanArchitecture
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormMain(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormBrand>();
            frm.ShowDialog();
        }

        private void cervezasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormBeer>();
            frm.ShowDialog();
        }
    }
}
