export default function Modal(
    title: string,
    children: React.ReactNode,
    handleClick: React.MouseEventHandler<HTMLButtonElement>
) {
    return (
        <div
            className="modal fade"
            id="staticBackdrop"
            data-bs-backdrop="static"
            data-bs-keyboard="false"
            aria-labelledby="staticBackdropLabel"
            aria-hidden="true"
        >
            <div className="modal-dialog modal-lg modal-dialog-centered">
                <div className="modal-content">
                    <div className="modal-header bg-dark">
                        <h2
                            className="modal-title text-white"
                            id="staticBackdropLabel"
                        >
                            {title}
                        </h2>
                        <button
                            onClick={handleClick}
                            aria-label="Close"
                            type="button"
                            className="btn-close btn-close-white"
                        ></button>
                    </div>
                    <div className="modal-body">{children}</div>
                </div>
            </div>
        </div>
    );
}
