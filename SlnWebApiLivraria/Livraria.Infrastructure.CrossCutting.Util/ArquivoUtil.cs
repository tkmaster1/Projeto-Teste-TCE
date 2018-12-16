using System;
using System.IO;
using System.Linq;
using System.Web;

namespace Livraria.Infrastructure.CrossCutting.Util
{
    public class ArquivoUtil
    {
        public static string UrlBaseEvidencias = "/Uploads/";
        public static string PathEvidencia = HttpContext.Current.Server.MapPath(UrlBaseEvidencias);

        public static void SalvarArquivo(string path, string fileName, byte[] bytes)
        {
            string serverMapPath = HttpContext.Current.Server.MapPath(path);
            bool exists = Directory.Exists(serverMapPath);

            DirectoryInfo info;

            info = !exists ? Directory.CreateDirectory(serverMapPath) : new DirectoryInfo(serverMapPath);

            if (fileName != null)
            {
                string filePath = Path.Combine(info.FullName, Path.GetFileName(fileName));

                using (var imageFile = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }
            }
        }

        public static void SalvarArquivo(string path, string fileName, HttpPostedFile file)
        {
            string serverMapPath = HttpContext.Current.Server.MapPath(path);
            bool exists = Directory.Exists(serverMapPath);
            string filePath = string.Empty;
            DirectoryInfo info;

            info = !exists ? Directory.CreateDirectory(serverMapPath) : new DirectoryInfo(serverMapPath);

            if (fileName != null)
            {
                filePath = Path.Combine(info.FullName, Path.GetFileName(fileName));
                if (File.Exists(filePath))
                {
                    filePath = Path.Combine(info.FullName, Path.GetFileName(GetNextFileName(fileName)));
                }

                file.SaveAs(filePath);
            }
        }

        public static void DeletarArquivo(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void BaixarArquivo(string nomeEvidencia, string caminho, HttpContext context)
        {
            string attachment = "attachment; filename=" + nomeEvidencia;
            context.Response.AppendHeader("content-disposition", attachment);
            context.Response.AppendHeader("Sebrae", "public");
            var arquivo = caminho + nomeEvidencia;
            var pathArquivo = context.Server.MapPath(arquivo);
            context.Response.WriteFile(pathArquivo);
            context.Response.End();
        }

        public static string SalvarArquivoPorHttpPostedFileBase(HttpPostedFileBase file, HttpRequestBase request, string caminho, int maxLength, int id)
        {
            string nomeArquivo;

            if (request.Browser.Browser.ToUpper() == "IE" || request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
            {
                string[] explorerArquivo = file.FileName.Split(new char[] { '\\' });
                nomeArquivo = explorerArquivo[explorerArquivo.Length - 1];
            }
            else
            {
                nomeArquivo = file.FileName;
            }

            nomeArquivo = RetornarNomePadraoArquivo(nomeArquivo, id, maxLength);

            var pathArquivo = Path.Combine(HttpContext.Current.Server.MapPath(caminho), nomeArquivo);

            file.SaveAs(pathArquivo);

            return nomeArquivo;
        }

        public static string ReduzirNomeArquivo(int maxLength, string NomeArquivo)
        {
            if (NomeArquivo.Length > maxLength)
            {
                return NomeArquivo.Substring(0, maxLength);
            }
            return NomeArquivo;
        }

        public static string RetornarNomePadraoArquivo(string arquivoNome, int id, int maxLengh)
        {
            arquivoNome = arquivoNome.Replace(" ", "");
            arquivoNome = ReduzirNomeArquivo(maxLengh, arquivoNome);
            var nomeDoArquivo = arquivoNome.Split('.').First();
            var extensaoDoArquivo = arquivoNome.Split('.').Last();
            arquivoNome = string.Concat(nomeDoArquivo, "~", Guid.NewGuid().ToString(), id, ".", extensaoDoArquivo);

            return arquivoNome;
        }

        public static string RemoverHashArquivo(string arquivo)
        {
            var extensao = arquivo.Split('.').Last();
            var temp = arquivo.Split('.').First().Split('~').First();
            return string.Format("{0}.{1}", temp, extensao);
        }

        private static string GetNextFileName(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string pathName = Path.GetDirectoryName(fileName);
            string fileNameOnly = Path.Combine(pathName, Path.GetFileNameWithoutExtension(fileName));
            int i = 0;
            // If the file exists, keep trying until it doesn't
            while (File.Exists(fileName))
            {
                i += 1;
                fileName = string.Format("{0}({1}){2}", fileNameOnly, i, extension);
            }
            return fileName;
        }
    }
}
