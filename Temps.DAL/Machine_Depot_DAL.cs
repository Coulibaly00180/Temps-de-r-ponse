using Temps.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Temps.DAL
{
    public class Machine_Depot_DAL : Depot_DAL<Machine_DAL>
    {
        public override Machine_DAL Insert(Machine_DAL machine_DAL)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"INSERT INTO [dbo].[Machine]
                                ([MachineName]
                                ,[MachineDescription]
                                ,[ServiceDate]
                                ,[SignalTime]
                                ,[LocalTime])
                            VALUES
                                (@MachineName
                                ,@MachineDescription
                                ,@ServiceDate
                                ,@SignalTime
                                ,@LocalTime); select scope_identity()";
            Commande.Parameters.Add(new SqlParameter("@MachineName", machine_DAL.MachineName));
            Commande.Parameters.Add(new SqlParameter("@MachineDescription", machine_DAL.MachineDescription));
            Commande.Parameters.Add(new SqlParameter("@ServiceDate", machine_DAL.ServiceDate));
            Commande.Parameters.Add(new SqlParameter("@SignalTime", machine_DAL.SignalTime));
            Commande.Parameters.Add(new SqlParameter("@LocalTime", machine_DAL.LocalTime));

            machine_DAL.MachineNumber = Convert.ToInt32((decimal)Commande.ExecuteScalar());

            FermerEtDisposerLaConnexionEtLaCommande();

            return machine_DAL;
        }

        public override Machine_DAL GetById(int MachineNumber)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT MachineNumber,MachineName,MachineDescription,ServiceDate,SignalTime,LocalTime
                                    FROM [dbo].[Machine]
                                    WHERE MachineNumber=@MachineNumber";
            Commande.Parameters.Add(new SqlParameter("@MachineNumber", MachineNumber));

            var reader = Commande.ExecuteReader();

            Machine_DAL machine_DAL = null;

            if (reader.Read())
            {
                machine_DAL = new Machine_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetDateTime(3),
                                            reader.GetDateTime(4),                           
                                            reader.GetDateTime(5));
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return machine_DAL;
        }

        public override Machine_DAL Update(Machine_DAL machine_DAL)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"UPDATE [dbo].[Machine]
                                         set [MachineName]=@MachineName
                                        ,[MachineDescription]=@MachineDescription
                                        ,[ServiceDate]=@ServiceDate
                                        ,[SignalTime]=@SignalTime
                                        ,[LocalTime]=@LocalTime
                                    WHERE MachineNumber=@MachineNumber";

            Commande.Parameters.Add(new SqlParameter("@MachineNumber", machine_DAL.MachineNumber));
            Commande.Parameters.Add(new SqlParameter("@MachineName", machine_DAL.MachineName));
            Commande.Parameters.Add(new SqlParameter("@MachineDescription", machine_DAL.MachineDescription));
            Commande.Parameters.Add(new SqlParameter("@ServiceDate", machine_DAL.ServiceDate));
            Commande.Parameters.Add(new SqlParameter("@SignalTime", machine_DAL.SignalTime));
            Commande.Parameters.Add(new SqlParameter("@LocalTime", machine_DAL.LocalTime));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();

            return machine_DAL;
        }

        public override Machine_DAL UpdateSignal(Machine_DAL machine_DAL)
        {
            InitialiserLaConnexionEtLaCommande();
            Commande.CommandText = @"UPDATE [dbo].[Machine]
                                         set [MachineNumber]=@MachineNumber
                                        ,[SignalTime]=@SignalTime
                                        ,[LocalTime]=@LocalTime
                                    WHERE MachineNumber=@MachineNumber";

            Commande.Parameters.Add(new SqlParameter("@MachineNumber", machine_DAL.MachineNumber));
            Commande.Parameters.Add(new SqlParameter("@SignalTime", machine_DAL.SignalTime));
            Commande.Parameters.Add(new SqlParameter("@LocalTime", machine_DAL.LocalTime));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();

            return machine_DAL;
        }

        public override void Delete(int MachineNumber)
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"DELETE FROM [dbo].[Machine]
                                     WHERE MachineNumber=@MachineNumber";

            Commande.Parameters.Add(new SqlParameter("@MachineNumber", MachineNumber));
            Commande.ExecuteNonQuery();

            FermerEtDisposerLaConnexionEtLaCommande();
        }

        public override IEnumerable<Machine_DAL> GetAll()
        {
            InitialiserLaConnexionEtLaCommande();

            Commande.CommandText = @"SELECT MachineNumber,MachineName,MachineDescription,ServiceDate,SignalTime,LocalTime
                                    FROM [dbo].[Machine]";


            var reader = Commande.ExecuteReader();

            var liste = new List<Machine_DAL>();

            while (reader.Read())
            {
                liste.Add(new Machine_DAL(reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.GetString(2),
                                            reader.GetDateTime(3),
                                            reader.GetDateTime(4),
                                            reader.GetDateTime(5)
                                            
                ));
            }

            FermerEtDisposerLaConnexionEtLaCommande();

            return liste;
        }
    }
}
