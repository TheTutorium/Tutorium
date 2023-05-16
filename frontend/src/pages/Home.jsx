export function Home() {
  return (
    <>
      <div
        className="
        max-w-[1400px]
        mx-auto
        self-stretch
        w-full  
    "
      >
        <div className="flex flex-col items-center">
          <div className="flex flex-col md:flex-row mt-5 md:mt-20">
            <div className=" flex flex-col justify-center">
              {" "}
              <h1 className="text-5xl font-bold text-center text-primary p-3">
                Every Master, Was Once A Cekirge
              </h1>
              <p className="mt-4 text-center text-muted-foreground text-lg md:text-xl">
                Reinventing the peer-to-peer learning experience, one hop at a
                time.
              </p>
            </div>
            <img
              className="rounded-full w-1/2 max-w-[400px] min-w-[200px] mx-auto m-5 md:m-2"
              src="/grasshopper.png"
              alt="Cekirge"
            />
          </div>
        </div>
      </div>

      <div className="mt-5 md:mt-20 w-full bg-secondary p-3" id="about">
        <h1 className="text-3xl text-center font-bold text-primary p-3">
          By Students For Students
        </h1>
        <p className=" text-center text-muted-foreground text-lg md:text-xl p-3 max-w-[700px] mx-auto">
          Tutorium is a peer-to-peer learning platform that aims to connect
          students with each other to help them learn from each other. We
          believe that students can learn better from each other than from their
          professors. We also believe that students can teach better than their
          professors. We are here to help students learn from each other and
          teach each other.
        </p>
        <h1 className="text-3xl text-center font-bold text-primary p-3 mt-5 md:mt-20">
          About Tutorium
        </h1>
        <p className=" text-center text-muted-foreground text-lg md:text-xl p-3 max-w-[700px] mx-auto">
          Landing page shit iste klasik doldurcaz burlari ilustrasyon vs koymayi
          dusunebilriz benim aklimda sener senin cekirge sahnesi var ama
          bilemedim
        </p>
      </div>
    </>
  );
}

Home.displayName = "Home";
